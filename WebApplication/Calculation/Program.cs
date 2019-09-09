using System;

namespace Calculation
{
    public class Calculation
    {
        private double faiz;
        private int kredi;
        private int ay;
        private double taksitT;
        private double kalanAna;
        public double toplamGeriodeme;
        public Calculation()
        {
            faiz = 0.01;
            kredi = 100;
            ay = 12;
            kalanAna = 100;
            taksitTutar();
        }
        /*
         * 
        [
         {
            "taksitNo": 1,
            "taksitTutar" : 8,88,
            "odenenFaiz" : 1,
            "odenenTutar" : 7,88,
            "kalanAnaPara" : 92,12
         },
         {}
         ]
             
             */
        public string Hesap()
        {
            int sayac = 1;
            string jsonData="[";
            toplamGeriodeme = kredi;
            double of=0, ot=0;//of=odenen faiz  ot=odenenTutar
            do
            {
                if (kalanAna - taksitT <= 0)
                {
                    of = odenenFaiz(kalanAna);
                    toplamGeriodeme += of;
                    ot = taksitT - of;
                    Math.Round(ot, 2);
                    jsonData += "{ \"taksitNo\":" + sayac + ",";
                    taksitT = of + ot;
                    jsonData += "\"taksitTutar:" + taksitT + ",";
                    jsonData += "\"odenenFaiz:" + of + ",";
                    jsonData += "\"odenenTutar:" + ot + ",";
                    kalanAna = 0;
                    jsonData += "\"kalanAna:" + kalanAna +"}]";
                }
                else
                {
                    jsonData += "{ \"taksitNo\":" + sayac + ",";

                    jsonData += "\"taksitTutar\":" + taksitT + ",";
                    of = odenenFaiz(kalanAna);
                    toplamGeriodeme += of;
                    jsonData += "\"odenenFaiz\":" + of + ",";
                    ot = taksitT - of;
                    Math.Round(ot, 2);
                    jsonData += "\"odenenTutar\":" + ot + ",";
                    kalanAna = kalanAna - ot;
                    Math.Round(kalanAna, 2);
                    jsonData += "\"kalanAna\":" + kalanAna + "},";
                    sayac++;
                }
                
            } while (kalanAna != 0);
            return jsonData;
        }
        public void taksitTutar()
        {
            double tTutar;

            tTutar = kredi * (faiz * Math.Pow(1 + faiz, ay)) / (Math.Pow(1 + faiz, ay) - 1);
            taksitT = Math.Round(tTutar, 2);
        }
        public double odenenFaiz(double k)
        {
            double oFaiz = k * faiz;
            return Math.Round(oFaiz, 2);
        }
        public double odenenAnapara(double k,double o)
        {
            return k-o;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculation c = new Calculation();
            //double cal =Math.Round( c.taksitTutar(),2);
            Console.WriteLine(c.Hesap()+c.toplamGeriodeme);
        }
    }
}
