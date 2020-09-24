using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    public partial class Form1 : Form
    {
        static string _url = "https://localhost:44396/WebService1.asmx";

        XmlSerializer formatter = new XmlSerializer(typeof(ArrayOfContact));
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            byte[] byteArray = Encoding.UTF8.GetBytes("params");
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://localhost:44396/WebService1.asmx/GetDist");
            rq.Method = "POST";
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = byteArray.Length;
            rq.MaximumResponseHeadersLength = 100;
            using (Stream dataStream = rq.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
            StreamReader rdr = new StreamReader(response.GetResponseStream());

            ArrayOfContact contacts;
            using (TextReader reader = new StringReader(rdr.ReadToEnd()))
            {
                contacts = (ArrayOfContact)formatter.Deserialize(reader);
            }
            foreach (Contact c in contacts.Contact)
            {
                ListViewItem item = new ListViewItem(c.Id.ToString());
                item.SubItems.Add(c.Surname.ToString());
                item.SubItems.Add(c.Phone.ToString());
                listBox1.Items.Add(item);
                //listBox1.Items.Add(c.Id.ToString() + ' ' + c.Surname + ' ' + c.Phone);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap12:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" 
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                 xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                 <soap12:Body>
                     <AddDict xmlns=""http://tempuri.org/"">
                     <Contact>
                       <Surname>{textBox2.Text}</Surname>
                       <Phone>{textBox3.Text}</Phone>
                     </Contact>
                    </AddDict>
                </soap12:Body>
            </soap12:Envelope>";
            string str = CallWebService(xml, "http://tempuri.org/AddDict");
           // listBox1.Items.Add(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap12:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" 
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                 xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                 <soap12:Body>
                     <UpdDict xmlns=""http://tempuri.org/"">
                         <Contact>
                           <Id>{textBox1.Text}</Id>
                           <Surname>{textBox2.Text}</Surname>
                           <Phone>{textBox3.Text}</Phone>
                         </Contact>
                    </UpdDict>
               </soap12:Body>
            </soap12:Envelope>";
            string str = CallWebService(xml, "http://tempuri.org/UpdDict");
           // listBox1.Items.Add(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap12:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" 
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                 xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                 <soap12:Body>
                     <DelDict xmlns=""http://tempuri.org/"">
                         <Contact>
                           <Id>{textBox1.Text}</Id>
                         </Contact>
                    </DelDict>
               </soap12:Body>
            </soap12:Envelope>";
            string str = CallWebService(xml, "http://tempuri.org/DelDict");
            //listBox1.Items.Add(str);
        }
        public string CallWebService(string xml, string action)
        {
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xml);
            HttpWebRequest webRequest = CreateWebRequest(_url, action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }
            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(String xml)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
