using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using HangfirePOC;
using Microsoft.Extensions.Configuration;
using Hangfire.Common;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage("Server=(localdb)\\mssqllocaldb;Database=Test;Trusted_Connection=True;"));
builder.Services.AddHangfireServer();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<FirstService>();
builder.Services.AddScoped<SecondService>();
builder.Services.AddScoped<SchedulerService>();



var app = builder.Build();

app.UseHangfireDashboard();

var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
var taskService = app.Services.GetRequiredService<TaskService>();
var firstService = app.Services.GetRequiredService<FirstService>();
var secondService = app.Services.GetRequiredService<SecondService>();

// Schedule tasks
Guid every2MinTaskId = Guid.NewGuid();
Guid every3MinTaskId = Guid.NewGuid();
Guid every5MinTaskId = Guid.NewGuid();
Guid everyHourTaskId = Guid.NewGuid();
Guid everyMondayAt8AMTaskId = Guid.NewGuid();
Guid firstOfTheMonthAt8AMTaskId = Guid.NewGuid();

Guid firstServiceTaskId = Guid.NewGuid();
Guid secondServiceTaskId = Guid.NewGuid();
// ... Generate Guids for other tasks

recurringJobManager.AddOrUpdate("Every2MinutesTask", () => taskService.Every2MinutesTask(every2MinTaskId), "*/2 * * * *");
recurringJobManager.AddOrUpdate("Every3MinutesTask", () => taskService.Every3MinutesTask(every3MinTaskId), "*/3 * * * *");
recurringJobManager.AddOrUpdate("Every5MinutesTask", () => taskService.Every5MinutesTask(every5MinTaskId), "*/5 * * * *");
recurringJobManager.AddOrUpdate("EveryHourTask", () => taskService.EveryHourTask(everyHourTaskId), "0 * * * *");
recurringJobManager.AddOrUpdate("EveryMondayAt8AMTask", () => taskService.EveryMondayAt8AMTask(everyMondayAt8AMTaskId), "0 8 * * 1");
recurringJobManager.AddOrUpdate("FirstOfTheMonthAt8AMTask", () => taskService.FirstOfTheMonthAt8AMTask(firstOfTheMonthAt8AMTaskId), "0 8 1 * *");

recurringJobManager.AddOrUpdate(
    "FirstServiceFirstOfMonthTask",
    () => firstService.FirstOfMonthTask(firstServiceTaskId),
    "0 8 1 * *");

//recurringJobManager.AddOrUpdate(
//    "SecondServiceFirstOfMonthTask",
//    () => secondService.FirstOfMonthTask(secondServiceTaskId),
//    "0 8 1 * *");

var schedulerService = app.Services.GetRequiredService<SchedulerService>();
Guid taskId = Guid.NewGuid();

recurringJobManager.AddOrUpdate(
    "SchedulerServicePreCheckTask",
    () => schedulerService.PreCheckTask(taskId),
    "*/2 * * * *"); // Original schedule


// ... Schedule other tasks similarly

app.Run();


/*
drop table[Test].[HangFire].AggregatedCounter
drop table [Test].[HangFire].[Counter]
drop table[Test].[HangFire].[Hash]
drop table[Test].[HangFire].Job
drop table [Test].[HangFire].JobParameter
drop table [Test].[HangFire].JobQueue
drop table [Test].[HangFire].List
drop table [Test].[HangFire].[Schema]
drop table[Test].[HangFire].[Server]
drop table[Test].[HangFire].[Set]
drop table[Test].[HangFire].[State]
*/