using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace MeasureFinger
{
    public partial class CanvasReport : Form
    {

        private ReportDocument _doc = new ReportDocument();
        private ParameterValues _Param = new ParameterValues();
        private ParameterDiscreteValue _Value = new ParameterDiscreteValue();
        private ParameterField _ParamField = new ParameterField();
        private ParameterFields _ParamFields = new ParameterFields();
        private Proxy _proxy = new Proxy();
        private string _KodePasien;

        public CanvasReport(string KodePasien)
        {
            InitializeComponent();
            _KodePasien = KodePasien;
            _LoadReport();
        }
         

        void _LoadReport()
        {
            DataTable _dtset = _proxy._GetPasien()._SelectHasilAnalisa(_KodePasien).Tables[0];
            DataSet _source = new DataSet();

            _source.ReadXmlSchema(ModuleStatic.SetPathUtama + "\\XsdReport.xsd");

            DataRow _row = _source.Tables[0].NewRow();
            for (int puter = 0; puter < _dtset.Columns.Count;puter++ )
            {
                // cek data jumlah sidik jari
                if (_dtset.Columns[puter].DataType == typeof(System.Double))
                {
                    if (_dtset.Columns[puter].ColumnName == "OTAK_KIRI" || _dtset.Columns[puter].ColumnName == "OTAK_KANAN" )
                        _row[_dtset.Columns[puter].ColumnName] = Convert.ToDouble(_dtset.Rows[0][puter]);
                    else
                        _row[_dtset.Columns[puter].ColumnName] = Convert.ToDouble(_dtset.Rows[0][puter]) / 100;
                }

               

            }

            for (int puter1 = 0; puter1 < _source.Tables[0].Columns.Count; puter1++)
            {
                if (_source.Tables[0].Columns[puter1].DataType == typeof(System.Byte[]))
                {
                    FileStream fs;
                    BinaryReader br;
                    fs = new FileStream(ModuleStatic.GetPathGambar + "\\"+ _KodePasien + "\\" + _source.Tables[0].Columns[puter1].ColumnName+ ".jpg", FileMode.Open);
                    br = new BinaryReader(fs);
                    byte[] imgbyte = new byte[fs.Length + 1];
                    imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                    _row[_source.Tables[0].Columns[puter1].ColumnName] = imgbyte;
                    br.Close();
                    fs.Close();
                }
            }


          

                
            _row["NAMA_PASIEN"] = _dtset.Rows[0]["NAMA_PASIEN"];
            _row["TANGGAL_ANALISA"] = _dtset.Rows[0]["TANGGAL_ANALISA"];
            _row["ID_PASIEN_ALIAS"] = _dtset.Rows[0]["ID_PASIEN_ALIAS"];
            _row["USIA"] = _dtset.Rows[0]["USIA"];
            _source.Tables[0].Rows.Add(_row);


            if (!ModuleStatic.GetSetTrial)
            {
                _doc.Load(ModuleStatic.SetPathUtama + "\\MyReport.rpt");
                _doc.SetDataSource(_source.Tables[0]);
            }
            else
            {
                _doc.Load(ModuleStatic.SetPathUtama + "\\Rpt.rpt");
            }
           
          
            _CrView.ReportSource = _doc;
        }



    }
}
