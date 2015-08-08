/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  VaildCode
 * 版本号：  V1.0.0.0
 * 唯一标识：7378b42e-d21b-426b-8948-6069035cc0ff
 * 创建人：  成刚
 * 创建时间：2015/8/8 18:20:27
 * 描述：
 *
 *=====================================================================
 * 修改标记
 * 修改时间：
 * 修改人： 
 * 版本号： 
 * 描述：
 *
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sys.Common
{
    public class VaildCode
    {
        private int codeLen = 4;//验证码长度 
        private int fineness = 85;//图片清晰度 
        private int imgWidth = 100;//图片宽度 
        private int imgHeight = 30;//图片高度 
        private string fontFamily = "Times New Roman";//字体名称 
        private int fontSize = 20;//字体大小 
        //private int fontStyle = 0;//字体样式 
        private int posX = 20;//绘制起始坐标X 
        private int posY = 0;//绘制坐标Y 
        private string CreateValidateCode() //生成验证码 
        {
            string validateCode = "";
            //Random random = new Random();// 随机数对象 
            //for (int i = 0; i < codeLen; i++)//循环生成每位数值 
            //{
            //    int n = random.Next(10);//数字 
            //    validateCode += n.ToString();
            //}
            validateCode = CreateRandomCode(codeLen);
            HttpContext.Current.Session.Add("vcode", validateCode);
            return validateCode;// 返回验证码 
        }
        private string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(61);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        private void DisturbBitmap(Bitmap bitmap)//图像背景 
        {
            Random random = new Random();//通过随机数生成 
            for (int i = 0; i < bitmap.Width; i++)//通过循环嵌套，逐个像素点生成 
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (random.Next(90) <= this.fineness)
                        bitmap.SetPixel(i, j, Color.FromArgb(247, 248, 250));
                }
            }
        }

        private void DrewValidateCode(Bitmap bitmap, string validateCode)//绘制验证码图像 
        {
            Graphics g = Graphics.FromImage(bitmap);//获取绘制器对象 
            Font font = new Font(fontFamily, fontSize, FontStyle.Bold);//设置绘制字体 
            g.DrawString(validateCode, font, Brushes.LightSkyBlue, posX, posY);//绘制验证码图像 
        }

        public Bitmap Draw()
        {
            Random random = new Random();
            string validateCode = CreateValidateCode();//生成验证码 
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);//生成Bitmap图像 
            DisturbBitmap(bitmap); //图像背景 
            DrewValidateCode(bitmap, validateCode);//绘制验证码图像 
            bitmap = TwistImage(bitmap, true, random.Next(1, 5), random.Next(4, 6));
            bitmap.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Gif);//保存图像，等待输出 
            return bitmap;
        }

        public byte[] GetImgByte()
        {
            Random random = new Random();
            string validateCode = CreateValidateCode();//生成验证码 
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);//生成Bitmap图像 
            DisturbBitmap(bitmap); //图像背景 
            DrewValidateCode(bitmap, validateCode);//绘制验证码图像 
            MemoryStream stream = new MemoryStream();
            bitmap = TwistImage(bitmap, true, random.Next(1, 3), random.Next(4, 6));
            bitmap.Save(stream, ImageFormat.Jpeg);
            //输出图片流
            return stream.ToArray();
        }

        public System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            double PI = 6.283185307179586476925286766559;
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            Graphics graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI * (double)j) / dBaseAxisLen : (PI * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            srcBmp.Dispose();
            return destBmp;
        }
    }
}
