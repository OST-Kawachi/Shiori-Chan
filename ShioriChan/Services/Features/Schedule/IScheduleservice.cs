using System;
using System.Collections.Generic;
using System.Text;

namespace ShioriChan.Services.Features.Schedule
{


        /// <summary>
        /// 部屋情報
        /// </summary>
        public interface IScheduleservice
        {

            /// <summary>
            /// //5分前通知
            /// </summary>
            /// <param name="parameter">パラメータ</param>
            Task Notification(JToken parameter);



        }
}
