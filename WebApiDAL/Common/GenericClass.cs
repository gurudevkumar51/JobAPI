﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.IO;
using ImageProcessor;
using System.Drawing;
using System.Configuration;
using WebApiDAL.Entity;
using System.Net.Mail;
using System.Net;

namespace WebApiDAL.Common
{
    public class GenericClass
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }

        public static string IntToStringMonth(int value)
        {
            string month = "";
            switch (value)
            {
                case 1:
                    month = "January"; break;
                case 2:
                    month = "February"; break;
                case 3:
                    month = "March"; break;
                case 4:
                    month = "April"; break;
                case 5:
                    month = "May"; break;
                case 6:
                    month = "June"; break;
                case 7:
                    month = "July"; break;
                case 8:
                    month = "August"; break;
                case 9:
                    month = "September"; break;
                case 10:
                    month = "October"; break;
                case 11:
                    month = "November"; break;
                case 12:
                    month = "December"; break;
                default:
                    month = "invalid Month number";
                    break;
            }
            return month;
        }

        public static string Encode(string text, string purpose)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            byte[] stream = Encoding.UTF8.GetBytes(text);
            byte[] encodedValue = MachineKey.Protect(stream, purpose);
            return HttpServerUtility.UrlTokenEncode(encodedValue);
        }
       
        public static string Decode(string text, string purpose)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            byte[] stream = HttpServerUtility.UrlTokenDecode(text);
            byte[] decodedValue = MachineKey.Unprotect(stream, purpose);
            return Encoding.UTF8.GetString(decodedValue);
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        //compress file
        public static byte[] CompressSize(byte[] image)
        {
            int profileHeight = Convert.ToInt32(ConfigurationManager.AppSettings["ProfileHeight"]);
            int profileWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ProfileWidth"]);
            int profileQualityMax = Convert.ToInt32(ConfigurationManager.AppSettings["ProfileQualityMax"]);
            int profileQualityMin = Convert.ToInt32(ConfigurationManager.AppSettings["ProfileQualityMin"]);
            int profileSize = Convert.ToInt32(ConfigurationManager.AppSettings["ProfileSize"]);

            Size sz = new Size(profileHeight, profileWidth);

            while (image.Length >= profileSize && profileQualityMax >= profileQualityMin)
            {
                image = CompressImage(image, sz, profileQualityMax);
                profileQualityMax = profileQualityMax - 1;
                sz.Height = sz.Height - 2;
                sz.Width = sz.Width - 2;
            }
            return image;
        }

        public static byte[] CompressImage(byte[] bytecode, Size dimension, int quality)
        {
            using (MemoryStream inStream = new MemoryStream(bytecode))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory())
                    {
                        imageFactory.Load(inStream)
                            .Resize(dimension)
                                    .Quality(quality)
                                    .Save(outStream);
                    }
                    var p = outStream.Length;
                    using (var binaryReader = new BinaryReader(outStream))
                        bytecode = binaryReader.ReadBytes(Convert.ToInt32(p));
                }
            }
            return bytecode;
        }

        public static Boolean sendMail(EmailTemplate mailDetails, SmtpMail smtpDetails)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(mailDetails.Mail_To);
            if (!String.IsNullOrEmpty(mailDetails.Mail_bcc))
                mail.Bcc.Add(mailDetails.Mail_bcc);
            if (!String.IsNullOrEmpty(mailDetails.Mail_Cc))
                mail.CC.Add(mailDetails.Mail_Cc);
            if (!String.IsNullOrEmpty(Convert.ToString(smtpDetails.Smtp_mailfrom)))
                mail.From = new MailAddress(smtpDetails.Smtp_mailfrom);
            mail.Subject = mailDetails.Mail_Subject;
            string Body = mailDetails.Mail_Content;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpDetails.Smtp_Host;
            smtp.Port = smtpDetails.Smtp_Port;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(smtpDetails.Smtp_username, smtpDetails.Smtp_password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return false;
        }
    }
}
