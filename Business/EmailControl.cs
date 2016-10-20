using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net.Mail.SmtpClient;
using System.Net.Mail;
using System.Data;
using BHair.Business.Table;
using BHair.Business.BaseData;
using System.Data.OleDb;

namespace BHair.Business
{
    public class EmailControl
    {
        public static Users users = new Users();
        public static Business.BaseData.SetupConfig config = new BaseData.SetupConfig();
        public static string strTableName = "MailTrans";
        /// <summary>
        /// 以163邮箱发送邮件
        /// </summary>
        /// <param name="Subject">标题</param>
        /// <param name="Body">正文</param>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>发送成功</returns>
        public static bool SendEmail(string Subject, string Body, string TargetAddress)
        {
            string id = config.EmailID;
            string pwd = config.EmailPwd;
            string address = config.EmailAddress;
            string smtp = config.EmailSMTP;

            bool isSuccess = false;//是否成功发送

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            //client.Host = smtp;//使用163的SMTP服务器发送邮件
            //client.UseDefaultCredentials = true;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.Credentials = new System.Net.NetworkCredential(id, pwd);//163的SMTP服务器需要用163邮箱的用户名和密码作认证，如果没有需要去163申请个,
            //System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            //Message.From = new System.Net.Mail.MailAddress(address);//这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
            ////因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com
            ////Message.To.Add("123456@gmail.com");//将邮件发送给Gmail
            ////Message.To.Add("12345@qq.com");//将邮件发送给QQ邮箱
            if (TargetAddress != "")
            {
                try
                {
                    //Message.To.Add(TargetAddress);
                    //Message.Subject = Subject;
                    //Message.Body = Body;
                    //Message.SubjectEncoding = System.Text.Encoding.UTF8;
                    //Message.BodyEncoding = System.Text.Encoding.UTF8;
                    //Message.Priority = System.Net.Mail.MailPriority.High;
                    //Message.IsBodyHtml = true;

                    //users.UsersDT = users.SelectAllUsers("");
                    //client.Send(Message);
                    string strSQL2 = "insert into MailTrans(MailSubject,MailBody,MailTargetAddress,Flag) ";
                    strSQL2 = strSQL2 + " Values('" + Subject + "','" + Body + "','" + TargetAddress + "',0) ";
                    AccessHelper ah2 = new AccessHelper();
                    OleDbCommand comm2 = new OleDbCommand(strSQL2, ah2.Conn);
                    comm2.ExecuteNonQuery();
                    isSuccess = true;
                    ah2.Close();
                }
                catch (Exception ex1)
                {
                    if (ex1.HResult.ToString() == "-2147217865")
                    {
                        try
                        {
                            AccessHelper ah = new AccessHelper();
                            string strInSQL = "create table MailTrans(id autoincrement,MailSubject longtext,MailBody longtext,MailTargetAddress longtext,Flag int)";
                            OleDbCommand comm = new OleDbCommand(strInSQL, ah.Conn);
                            comm.ExecuteNonQuery();
                            string strSQL2 = "insert into MailTrans(MailSubject,MailBody,MailTargetAddress,Flag) ";
                            strSQL2 = strSQL2 + " Values('" + Subject + "','" + Body + "','" + TargetAddress + "',0) ";
                            AccessHelper ah2 = new AccessHelper();
                            OleDbCommand comm2 = new OleDbCommand(strSQL2, ah2.Conn);
                            comm2.ExecuteNonQuery();
                            isSuccess = true;
                            ah.Close();
                            ah2.Close();
                        }
                        catch (Exception ex2)
                        {                           
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return isSuccess;
        }


        

        /// <summary>
        /// 发给商品部最终确认，发送邮件给商品部
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantFinal(ApplicationInfo ai)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：" + ai.DeliverStore + "到" + ai.ReceiptStore + ",在" + DateTime.Now.ToString() + "的转货流程已完成，需要最终确认");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.CtrlID, ai.ApplicantsName, ai.ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    if (dr["Character"].ToString() == "1")
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }

        /// <summary>
        /// 申请成功后发送邮件给商品部
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantSubmit(string CtrlID, string ApplicantsName, string ApplicantsDate)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：有一单转货单需要审核");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", CtrlID, ApplicantsName, ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    if (dr["Character"].ToString() == "1")
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 商品部审批成功后发送邮件给财务部
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantSubmit2(ApplicationInfo ai)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：" + ai.DeliverStore + "到" + ai.ReceiptStore + ",在" + DateTime.Now.ToString() + "的转货流程需要审核");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.CtrlID, ai.ApplicantsName, ai.ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    if (dr["Character"].ToString() == "2")
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 财务部审批后发送邮件给转出店面
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool ToDeliverConfirm(ApplicationInfo ai)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：" + ai.DeliverStore + "到" + ai.ReceiptStore + ",在" + DateTime.Now.ToString() + "的转货流程需要填写转出确认");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.CtrlID, ai.ApplicantsName, ai.ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    GenClass gc = new GenClass();
            //    if (gc.boolStore(ai.DeliverStore,dr["Store"].ToString()))
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 转出店面确认后发送邮件给转入店面
        /// </summary>
        /// <param name="TargetAddress"></param>
        /// <returns></returns>
        public static bool ToReceiptConfirm(ApplicationInfo ai)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：" + ai.DeliverStore + "到" + ai.ReceiptStore + ",在" + DateTime.Now.ToString() + "的转货流程需要填写转入确认");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.CtrlID, ai.ApplicantsName, ai.ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    GenClass gc = new GenClass();
            //    if (gc.boolStore(ai.ReceiptStore,dr["Store"].ToString()))
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }

        /// <summary>
        /// 转出店面的转货申请提交成功后发送邮件给物流部
        /// </summary>
        /// <param name="TargetAddress">目标地址</param>
        /// <returns>成功</returns>
        public static bool ToApplicantWLSubmit(ApplicationInfo ai)
        {
            //bool isSuccess = false;
            //string Subject = string.Format("转货系统：" + ai.DeliverStore + "到" + ai.ReceiptStore + ",在" + DateTime.Now.ToString() + "的转货流程需要物流确认");
            //string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", ai.CtrlID, ai.ApplicantsName, ai.ApplicantsDate);
            //foreach (DataRow dr in users.UsersDT.Rows)
            //{
            //    if (dr["Character"].ToString() == "4")
            //    {
            //        SendEmail(Subject, Body, dr["Email"].ToString());
            //    }
            //}
            return true;
        }


        /// <summary>
        /// 申请批准后超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <param name="ApplicantsName"></param>
        /// <param name="ApplicantsDate"></param>
        /// <param name="DeliverStore"></param>
        /// <returns></returns>
        public static bool ToAlertApproval(string CtrlID, string ApplicantsName, string ApplicantsDate, string DeliverStore)
        {
            bool isSuccess = false;
            string Subject = string.Format("转货系统：申请批准后超时提醒");
            string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", CtrlID, ApplicantsName, ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                GenClass gc = new GenClass();
                if (gc.boolStore( DeliverStore,dr["Store"].ToString() )|| dr["Character"].ToString()=="1")
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return true;
        }


        /// <summary>
        /// 发货后超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <param name="ApplicantsName"></param>
        /// <param name="ApplicantsDate"></param>
        /// <param name="DeliverStore"></param>
        /// <returns></returns>
        public static bool ToAlertDeliver(string CtrlID, string ApplicantsName, string ApplicantsDate, string DeliverStore, string ReceiptStore)
        {
            bool isSuccess = false;
            string Subject = string.Format("转货系统：发货后超时提醒");
            string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", CtrlID, ApplicantsName, ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                GenClass gc = new GenClass();
                if (gc.boolStore(DeliverStore,dr["Store"].ToString()) || dr["Character"].ToString() == "4" || gc.boolStore(ReceiptStore, dr["Store"].ToString()))
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return true;
        }


        /// <summary>
        /// 收货后超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <param name="ApplicantsName"></param>
        /// <param name="ApplicantsDate"></param>
        /// <param name="DeliverStore"></param>
        /// <returns></returns>
        public static bool ToAlertReceipt(string CtrlID, string ApplicantsName, string ApplicantsDate, string DeliverStore, string ReceiptStore)
        {
            bool isSuccess = false;
            string Subject = string.Format("转货系统：收货后超时提醒");
            string Body = string.Format(@"转货流程详情：\r\n控制号：{0}\r\n申请人：{1}\r\n申请日期：{2}\r\n", CtrlID, ApplicantsName, ApplicantsDate);
            foreach (DataRow dr in users.UsersDT.Rows)
            {
                if (dr["Character"].ToString() == "4")
                {
                    SendEmail(Subject, Body, dr["Email"].ToString());
                }
            }
            return true;
        }
    }


}
