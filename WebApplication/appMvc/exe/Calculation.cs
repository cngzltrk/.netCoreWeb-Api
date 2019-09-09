using appMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appMvc.exe
{
    public class Calculation
    {
        private double faiz;
        private int kredi;
        private int ay;
        private double taksitT;
        private double kalanAna;
        public double toplamGeriodeme;
        public Calculation(Veri v)
        {
            faiz =Faiz.faiz;
            kredi = v.tutar;
            ay = v.ay;
            kalanAna = kredi;
            taksitT=taksitTutar();
        }

        public string Hesap()
        {
            int sayac = 1;
            string jsonData = "[";
            toplamGeriodeme = kredi;
            double of = 0, ot = 0;//of=odenen faiz  ot=odenenTutar
            do
            {
                if (kalanAna - taksitT <= 0)
                {
                    of = odenenFaiz(kalanAna);
                    toplamGeriodeme += of;
                    ot = taksitT - of;
                    jsonData += "{'taksitNo':" + sayac + ",";
                    taksitT = of + ot;
                    jsonData += "'taksitTutar':" + taksitT.ToString().Replace(",", ".") + ",";
                    jsonData += "'odenenFaiz':" + of.ToString().Replace(",", ".") + ",";
                    jsonData += "'odenenTutar':" + ot.ToString().Replace(",", ".") + ",";
                    kalanAna = 0;
                    jsonData += "'kalanAna':" + kalanAna + "}]";
                }
                else
                {
                    jsonData += "{'taksitNo':" + sayac + ",";

                    jsonData += "'taksitTutar':" + taksitT.ToString().Replace(",",".") + ",";
                    of = odenenFaiz(kalanAna);
                    toplamGeriodeme += of;
                    jsonData += "'odenenFaiz':" + of.ToString().Replace(",", ".") + ",";
                    ot = taksitT - of;
                    jsonData += "'odenenTutar':" + ot.ToString().Replace(",", ".") + ",";
                    kalanAna = kalanAna - ot;
                    jsonData += "'kalanAna':" + kalanAna.ToString().Replace(",", ".") + "},";
                    sayac++;
                }

            } while (kalanAna != 0);

            return jsonData.Replace("'","\"");
        }
        public double taksitTutar()
        {
            double tTutar;
            tTutar = kredi * (faiz * Math.Pow(1 + faiz, ay)) / (Math.Pow(1 + faiz, ay) - 1);
            return Math.Round(tTutar, 2);
        }
        public double odenenFaiz(double k)
        {
            double oFaiz = k * faiz;
            return Math.Round(oFaiz, 2);
        }
        


    }

}
