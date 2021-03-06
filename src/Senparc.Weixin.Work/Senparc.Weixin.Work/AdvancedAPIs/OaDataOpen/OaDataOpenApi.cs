﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc
    
    文件名：SsoApi.cs
    文件功能描述：OA数据开放接口（Work中新增）
    
    
    创建标识：Senparc - 20170617

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senparc.Weixin.Work.AdvancedAPIs.OaDataOpen
{
    /// <summary>
    /// OA数据开放接口
    /// </summary>
    public class OaDataOpenApi
    {
        /// <summary>
        /// 打卡类型
        /// </summary>
        public enum OpenCheckinDataType
        {
            上下班打卡 = 1,
            外出打卡 = 2,
            全部打卡 = 3
        }

        #region 同步接口

        /// <summary>
        /// 获取打卡数据【QY移植新增】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openCheckinDataType">打卡类型</param>
        /// <param name="startTime">获取打卡记录的开始时间</param>
        /// <param name="endTime">获取打卡记录的结束时间</param>
        /// <param name="userIdList">需要获取打卡记录的用户列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static GetCheckinDataJsonResult GetCheckinData(string accessToken, OpenCheckinDataType openCheckinDataType, DateTime startTime, DateTime endTime, string[] userIdList, int timeOut = Config.TIME_OUT)
        {
            var url = "https://qyapi.weixin.qq.com/cgi-bin/checkin/getcheckindata?access_token={0}";

            var data = new
            {
                opencheckindatatype = (int)openCheckinDataType,
                starttime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(startTime),
                endtime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(endTime),
                useridlist = userIdList
            };

            return Senparc.Weixin.CommonAPIs.CommonJsonSend.Send<GetCheckinDataJsonResult>(null, url, data, CommonJsonSendType.POST, timeOut);
        }


        /// <summary>
        /// 获取审批数据【QY移植新增】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openCheckinDataType">打卡类型</param>
        /// <param name="startTime">获取打卡记录的开始时间</param>
        /// <param name="endTime">获取打卡记录的结束时间</param>
        /// <param name="userIdList">需要获取打卡记录的用户列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static GetApprovalDataJsonResult GetApprovalData(string accessToken, DateTime startTime, DateTime endTime, long next_spnum, int timeOut = Config.TIME_OUT)
        {
            var url = "https://qyapi.weixin.qq.com/cgi-bin/corp/getapprovaldata?access_token={0}";

            var data = new
            {
                starttime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(startTime),
                endtime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(endTime),
                next_spnum = next_spnum
            };

            return Senparc.Weixin.CommonAPIs.CommonJsonSend.Send<GetApprovalDataJsonResult>(null, url, data, CommonJsonSendType.POST, timeOut);
        }



        #endregion

        #region 异步接口

        /// <summary>
        /// 【异步接口】获取打卡数据【QY移植新增】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openCheckinDataType">打卡类型</param>
        /// <param name="startTime">获取打卡记录的开始时间</param>
        /// <param name="endTime">获取打卡记录的结束时间</param>
        /// <param name="userIdList">需要获取打卡记录的用户列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<GetCheckinDataJsonResult> GetCheckinDataAsync(string accessToken, OpenCheckinDataType openCheckinDataType, DateTime startTime, DateTime endTime, string[] userIdList, int timeOut = Config.TIME_OUT)
        {
            var url = "https://qyapi.weixin.qq.com/cgi-bin/checkin/getcheckindata?access_token={0}";

            var data = new
            {
                opencheckindatatype = (int)openCheckinDataType,
                starttime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(startTime),
                endtime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(endTime),
                useridlist = userIdList
            };

            return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<GetCheckinDataJsonResult>(null, url, data, CommonJsonSendType.POST, timeOut);
        }


        /// <summary>
        /// 【异步接口】获取审批数据【QY移植新增】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openCheckinDataType">打卡类型</param>
        /// <param name="startTime">获取打卡记录的开始时间</param>
        /// <param name="endTime">获取打卡记录的结束时间</param>
        /// <param name="userIdList">需要获取打卡记录的用户列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<GetApprovalDataJsonResult> GetApprovalDataAsync(string accessToken, DateTime startTime, DateTime endTime, long next_spnum, int timeOut = Config.TIME_OUT)
        {
            var url = "https://qyapi.weixin.qq.com/cgi-bin/corp/getapprovaldata?access_token={0}";

            var data = new
            {
                starttime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(startTime),
                endtime = Senparc.Weixin.Helpers.DateTimeHelper.GetWeixinDateTime(endTime),
                next_spnum = next_spnum
            };

            return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<GetApprovalDataJsonResult>(null, url, data, CommonJsonSendType.POST, timeOut);
        }

        #endregion
    }
}
