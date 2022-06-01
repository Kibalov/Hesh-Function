using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Hesh
{
    class Hesher
    {
        Data[] massN;
        Data[] massP;
        Data[] massB;
        int steps;
        public int Steps
        {
            get
            {
                return steps;
            }
            private set
            {
                steps = value;
            }
        }
        public Hesher(int length)
        {
            massN = new Data[length];
            massP = new Data[length];
            massB = new Data[length];
            steps = 0;
        }

        public bool AddN(Data data)
        {
            int n = 0;
            int k = Hesh(data.Name, massN.Length);
            while (n < massN.Length)
            {
                if (k >= massN.Length) k = 0;
                if (massN[k] == null) { massN[k] = data; return true; }
                else k++;
                n++;
            }
            return false;
        }
        public bool AddP(Data data)
        {
            int n = 0;
            int k = Hesh(data.Phone, massN.Length);
            while (n < massP.Length)
            {
                if (k >= massP.Length) k = 0;
                if (massP[k] == null) { massP[k] = data; return true; }
                else k++;
                n++;
            }
            return false;
        }
        public bool AddB(Data data)
        {
            int n = 0;
            int k = Hesh(data.DateOfBirthday, massB.Length);
            while (n < massB.Length)
            {
                if (k >= massB.Length) k = 0;
                if (massB[k] == null) { massB[k] = data; return true; }
                else k++;
                n++;
            }
            return false;
        }

        public Data FindN(string key)
        {
            int n = 0;
            int k = Hesh(key, massN.Length);
            while (n < massN.Length)
            {
                if (k >= massN.Length) k = 0;
                if (massN[k] == null) { break; }
                if (massN[k].Name == key) { steps = n; return massN[k]; }
                else k++;
                n++;
            }
            return null;
        }
        public Data FindP(string key)
        {
            int n = 0;
            int k = Hesh(key, massP.Length);
            while (n < massP.Length)
            {
                if (k >= massP.Length) k = 0;
                if (massP[k] == null) { break; }
                if (massP[k].Phone == key) { steps = n; return massP[k]; }
                else k++;
                n++;
            }
            return null;
        }
        public Data FindB(string key)
        {
            int n = 0;
            int k = Hesh(key, massB.Length);
            while (n < massB.Length)
            {
                if (k >= massB.Length) k = 0;
                if (massB[k] == null) { break; }
                if (massB[k].DateOfBirthday == key) { steps = n; return massB[k]; }
                else k++;
                n++;
            }
            return null;
        }
        public bool DeleteN(string key)
        {
            int n = 0;
            int k = Hesh(key, massN.Length);
            while (n < massN.Length)
            {
                if (k >= massN.Length) k = 0;
                if (massN[k] == null) { break; }
                if (massN[k].Name == key) { massN[k] = null; return true; }
                else k++;
                n++;
            }
            return false;
        }
        public bool DeleteP(string key)
        {
            int n = 0;
            int k = Hesh(key, massP.Length);
            while (n < massP.Length)
            {
                if (k >= massP.Length) k = 0;
                if (massP[k] == null) { break; }
                if (massP[k].Phone == key) { massP[k] = null; return true; }
                else k++;
                n++;
            }
            return false;
        }
        public bool DeleteB(string key)
        {
            int n = 0;
            int k = Hesh(key, massB.Length);
            while (n < massB.Length)
            {
                if (k >= massB.Length) k = 0;
                if (massB[k] == null) { break; }
                if (massB[k].DateOfBirthday == key) { massB[k] = null; return true; }
                else k++;
                n++;
            }
            return false;
        }

        int Hesh(string key, int length)
        {
            int k = 0;
            for (int i = 0; i < key.Length; i++)
            {
                k += key[i] * (i + 3) * (i + 10) * 343;
            }
            return Math.Abs(k % length);
        }

        public void Show(Chart chart, int ind)
        {
            int n = 0;
            if (ind == 1)
            {
                for (int i = 0; i < massN.Length; i++)
                {
                    if (i % 10000 == 0) { chart.Series[0].Points.AddXY(i / 10000, n); n = 0; }
                    if (massN[i] != null) n++;
                }
            }
            else if (ind==2)
            {
                for (int i = 0; i < massP.Length; i++)
                {
                    if (i % 10000 == 0) { chart.Series[0].Points.AddXY(i / 10000, n); n = 0; }
                    if (massP[i] != null) n++;
                }
            }
            else
            {
                for (int i = 0; i < massB.Length; i++)
                {
                    if (i % 10000 == 0) { chart.Series[0].Points.AddXY(i / 10000, n); n = 0; }
                    if (massB[i] != null) n++;
                }
            }
        }
    }
}
