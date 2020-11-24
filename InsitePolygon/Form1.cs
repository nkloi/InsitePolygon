using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsitePolygon
{
    public partial class Form1 : Form
    {
        public string currentDirect = Directory.GetCurrentDirectory();
        OpenFileDialog fdlg = new OpenFileDialog();

        public class Site
        {
            public string name;
            public locationPoint location;

        }

        public class Polygon
        {
            public string name;
            public List<locationPoint> polygon;
        }

        public class locationPoint
        {
            public double X, Y;
        }


        List<Site> lsSite = new List<Site>();
        List<Polygon> lsPolygon = new List<Polygon>();
        public Form1()
        {
            InitializeComponent();
        }

        private void lbSite_Click(object sender, EventArgs e)
        {
            string outputFile;
            int i = 0;
            outputFile = currentDirect + "\\" + "Form_List_Site" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".txt";
            StreamWriter swOut = new StreamWriter(outputFile);

            swOut.WriteLine("Site Name\tLong\tLat");
            swOut.WriteLine("HCM0001\t104.234252\t10.3434");
            swOut.WriteLine("HCM0002\t104.234252\t11.3434");
            swOut.Close();
            MessageBox.Show("Export from to: " + outputFile);
        }

        private void lbPolygon_Click(object sender, EventArgs e)
        {
            string outputFile;
            int i = 0;
            outputFile = currentDirect + "\\" + "Form_List_Polygon" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".txt";
            StreamWriter swOut = new StreamWriter(outputFile);

            swOut.WriteLine("Polygon Name\tLong\tLat");
            swOut.WriteLine("Polygon01\t104.234252\t10.3434");
            swOut.WriteLine("Polygon01\t104.34324\t11.6546");
            swOut.WriteLine("Polygon01\t104.6767\t10.45645");
            swOut.WriteLine("Polygon01\t104.3424\t11.7675");

            swOut.WriteLine("Polygon02\t104.768\t10.987");
            swOut.WriteLine("Polygon02\t104.67868\t11.89");
            swOut.WriteLine("Polygon02\t104.345\t10.789");
            swOut.WriteLine("Polygon02\t104.345\t11.789");
            swOut.Close();
            MessageBox.Show("Export from to: " + outputFile);
        }

        private void btBrowserSite_Click(object sender, EventArgs e)
        {
            if (currentDirect == "") currentDirect = Directory.GetCurrentDirectory();
            fdlg.Multiselect = false;
            fdlg.Title = "Open List of Site";
            fdlg.InitialDirectory = currentDirect;
            fdlg.Filter = "txt (*.txt)|*.txt";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sReader = new StreamReader(File.OpenRead(fdlg.FileName)))
                    {
                        string header = sReader.ReadLine();
                        while (!sReader.EndOfStream)
                        {
                            string sFileRead = sReader.ReadLine();
                            string[] oneLine = sFileRead.Split("\t,;".ToCharArray());
                            locationPoint tmpPoint = new locationPoint();
                            Site tmpSite = new Site();
                            tmpPoint.X = Convert.ToDouble(oneLine[1]);
                            tmpPoint.Y = Convert.ToDouble(oneLine[2]);
                            tmpSite.name = oneLine[0];
                            tmpSite.location = tmpPoint;
                            lsSite.Add(tmpSite);
                        }
                    }
                    txtListSite.Text = fdlg.FileName;
                    MessageBox.Show("Import list site ok");
                }
                catch {
                    MessageBox.Show("Can't import list site");
                }
            }
        }



        private void btBrowserPolygon_Click(object sender, EventArgs e)
        {
            if (currentDirect == "") currentDirect = Directory.GetCurrentDirectory();
            fdlg.Multiselect = false;
            fdlg.Title = "Open List of Site";
            fdlg.InitialDirectory = currentDirect;
            fdlg.Filter = "txt (*.txt)|*.txt";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sReader = new StreamReader(File.OpenRead(fdlg.FileName)))
                    {
                        string header = sReader.ReadLine();
                        string old = "-";
                        Polygon tmpPolygon = new Polygon();
                        tmpPolygon.polygon = new List<locationPoint>();
                        while (!sReader.EndOfStream)
                        {
                            string sFileRead = sReader.ReadLine();
                            string[] oneLine = sFileRead.Split("\t,;".ToCharArray());
                            if ((old != oneLine[0]) && (old != "-")) {
                                tmpPolygon.name = old;
                                lsPolygon.Add(tmpPolygon);
                                tmpPolygon = new Polygon();
                                tmpPolygon.polygon = new List<locationPoint>();
                            }
                            locationPoint tmpLocation = new locationPoint();
                            tmpLocation.X = Convert.ToDouble(oneLine[1]);
                            tmpLocation.Y = Convert.ToDouble(oneLine[2]);
                            tmpPolygon.polygon.Add(tmpLocation);
                            old = oneLine[0];
                        }
                        tmpPolygon.name = old;
                        lsPolygon.Add(tmpPolygon);
                    }
                    txtListPolygon.Text = fdlg.FileName;
                    MessageBox.Show("Import list polygon ok");
                }
                catch
                {
                    MessageBox.Show("Can't import list polygon");
                }
            }
        }



        private void btRun_Click(object sender, EventArgs e)
        {

            string outputFile = currentDirect + "\\" + "Result" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".txt";
            StreamWriter swOut = new StreamWriter(outputFile);

            swOut.WriteLine("Site\tLong\tLat\tPolygon");
            
            for (int i = 0; i < lsSite.Count; i++)
            {
                for (int j = 0; j < lsPolygon.Count; j++)
                {
                    if (checkInsitePolygon(lsSite[i].location, lsPolygon[j].polygon))
                    {
                        swOut.WriteLine(lsSite[i].name + "\t" + lsSite[i].location.X.ToString() + "\t" + lsSite[i].location.Y.ToString() + "\t" + lsPolygon[j].name);
                        break;
                    }
                }
            }

            swOut.Close();
            MessageBox.Show("Export from to: " + outputFile);
        }

        public static bool checkInsitePolygon(locationPoint A, List<locationPoint> input_polygon)
        {
            /*-----------------------------------------------------
            Xác định 1 điểm có nằm trong polygon hay không
            -----------------------------------------------------*/
            locationPoint P11 = new locationPoint();
            locationPoint intersectPoint;
            locationPoint Zero = new locationPoint();
            int numIntersect = 0;
            bool checkInter = false;
            Zero.X = 0;
            Zero.Y = 0;
            P11 = input_polygon[0];
            for (int j = 1; j < input_polygon.Count; j++)
            {
                if (P11.X != input_polygon[j].X || P11.Y != input_polygon[j].Y)
                {
                    intersectPoint = new locationPoint();
                    checkInter = Intersect2(P11, input_polygon[j], Zero, A, out intersectPoint);
                    if (checkInter) numIntersect++;
                }
                P11 = input_polygon[j];
            }
            intersectPoint = new locationPoint();
            checkInter = Intersect2(P11, input_polygon[0], Zero, A, out intersectPoint);
            if (checkInter) numIntersect++;
            return numIntersect % 2 != 0;
        }


        public static bool Intersect2(locationPoint P11, locationPoint P12, locationPoint P21, locationPoint P22, out locationPoint IntersectP)
        {
            /*-----------------------------------------------------
            Xác định 2 đường thẳng giao nhau
            -----------------------------------------------------*/
            double s02_x, s02_y, s10_x, s10_y, s32_x, s32_y, s_numer, t_numer, denom, t;
            s10_x = P12.X - P11.X;
            s10_y = P12.Y - P11.Y;
            s32_x = P22.X - P21.X;
            s32_y = P22.Y - P21.Y;
            IntersectP = new locationPoint();
            IntersectP.X = -1;
            IntersectP.Y = -1;
            denom = s10_x * s32_y - s32_x * s10_y;
            if (denom == 0)
            {
                //if (Is_In(P11.X,P21.X,P22.X) || Is_In(P12.X,P21.X,P22.X)) return true;
                return false; // Collinear
            }
            bool denomPositive = denom > 0;

            s02_x = P11.X - P21.X;
            s02_y = P11.Y - P21.Y;
            s_numer = s10_x * s02_y - s10_y * s02_x;
            if ((s_numer < 0) == denomPositive)
                return false; // No collision

            t_numer = s32_x * s02_y - s32_y * s02_x;
            if ((t_numer < 0) == denomPositive)
                return false; // No collision

            if (((s_numer > denom) == denomPositive) || ((t_numer > denom) == denomPositive))
                return false; // No collision
            // Collision detected
            t = t_numer / denom;
            IntersectP.X = P11.X + (t * s10_x);
            IntersectP.Y = P11.Y + (t * s10_y);

            return true;
        }

        
    }
}
