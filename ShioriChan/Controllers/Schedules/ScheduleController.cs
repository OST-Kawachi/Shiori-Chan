﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShioriChan.Services.Features.Schedules;

namespace ShioriChan.Controllers.Schedules {

	/// <summary>
	/// スケジュールController
	/// </summary>
	[Route( "shiori-chan" )]
	public class ScheduleController : Controller {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// スケジュールService
		/// </summary>
		private readonly IScheduleService scheduleService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		public ScheduleController(
			ILogger<ScheduleController> logger ,
			IScheduleService scheduleService
		)
		{
			this.logger = logger;
			this.scheduleService = scheduleService;
		}

		/// <summary>
		/// スケジュール情報を通知する
		/// </summary>
		[Route( "api/schedule" )]
		[HttpPost]
		public StatusCodeResult Post()
		{
			this.logger.LogInformation( "Start" );
			this.scheduleService.Notice();
			this.logger.LogInformation( "End" );
			return this.Ok();
		}

	}

}
