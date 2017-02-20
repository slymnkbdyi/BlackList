using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    string Chosen_File = "";

    long intAgain;
    string[] dizi = new string[16];
    string[] dizi2 = new string[8];
        string hexValue = "";
    int i;
    string son = "";
    string fname = "";
    string rfu = "";
    int durum;
    string gecici = "";
    string ilk_yaz = "";
    string directory = "";
    string ss = "";
    private void label1_Click(object sender, EventArgs e)
    {
    }       
    private void button1_Click(object sender, EventArgs e)
    {

      Random rd = new Random();
      int rn_sayi = rd.Next(1,5);

      FileStream fs = new FileStream(Chosen_File, FileMode.Open);
      int hexIn;
      long a = fs.Length - 1;
      if (directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101")
      {
        for (int i = 0; i < 4; i++)
        {
          fs.Position = a - 4 + i;
          hexIn = fs.ReadByte();
          dizi[i] = string.Format("{0:X2}", hexIn);
        }
        son = "" + dizi[3] + "" + "" + dizi[2] + "" + "" + dizi[1] + "" + "" + dizi[0] + "";
        }
      if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111"|| directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
      {
        for (int i = 0; i < 7; i++)
        {
          fs.Position = a - 8 + i;
          hexIn = fs.ReadByte();
          dizi[i] = string.Format("{0:X2}", hexIn);
        }
        son =   ""+dizi[2]  +""+  dizi[3] + "" + "" + dizi[4] + "" + dizi[5] + "" + "" + dizi[6] +"" ;
      }  
      fs.Close();
      try
      {
        var stream = File.Open(Chosen_File, FileMode.Append);
       intAgain = Convert.ToInt64(son, 16);
       
        long ilk_son = Convert.ToInt64(son, 16);
       
        
        for (int i = 1; i < numericUpDown1.Value+1; i++)
        {
                   
                    if (directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101")
                    {
                        if (checkBox1.Checked == true)
                        {

                            intAgain = ilk_son + 50 *rn_sayi* i+17;
                            ss = intAgain.ToString("X");


                        }
                        
                     
                        else
                        {
                            intAgain = intAgain + 1;
                           ss = intAgain.ToString();
                            son = intAgain.ToString();
                        }                    
                        if (ss.ToString().Length==1)
                        {
                            hexValue = "0000000" + ss + "";
                        }                      
                        if (ss.ToString().Length == 2)
                        {
                            hexValue = "000000" + ss + "";
                        }                   
                        if (ss.ToString().Length == 3)
                        {
                            hexValue = "00000" + ss + "";
                        }                      
                        if (ss.ToString().Length == 4)
                        {
                            hexValue = "0000" +ss + "";
                        }                     
                        if (ss.ToString().Length == 5)
                        {
                            hexValue = "000" + ss + "";
                        }                      
                        if (ss.ToString().Length == 6)
                        {
                            hexValue = "00" + ss + "";
                        }                    
                        if (ss.ToString().Length == 7)
                        {
                            hexValue = "0" + ss + "";
                        }                        
                        if (ss.ToString().Length == 8)
                        {
                            hexValue = "" + ss + "";
                        }                       
                        char[] charArr = hexValue.ToCharArray();
                        string[] dizi1 = new string[8];
                        for (int n = 0; n < charArr.Length; n++)
                        {
                            string current = charArr[n].ToString();
                            dizi1[n] = current;

                        }
                        hexValue= "" + dizi1[6] + "" + dizi1[7] + "" + dizi1[4] + "" + dizi1[5] + "" + dizi1[2] + "" + dizi1[3] + "" + dizi1[0] + "" + dizi1[1] + "";                                                                               
                        if (i % 10 == 0)
                        {
                            hexValue = ""+ hexValue + "80";                          
                        }
                        else
                        {
                            hexValue = "" + hexValue + "00";
                        }
                        WriteHexStringToFile(hexValue, stream);
                    }
                    if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111" || directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
                    {
                        int bas = 1;
                              if (checkBox1.Checked == true )
                              {
                                  
                              
                                   intAgain = ilk_son + 3 * i ;
                                    ss = intAgain.ToString("X");
                               
                             


                               }
                            
                             else
                                {
                                     intAgain = intAgain + 1;
                            ss = intAgain.ToString("X");
                        }

                              
                       
                         if (i < 2000)
                        {
                               bas = 0;
                         }
                        else
                       {
                              bas = i / 10000;
                      }
                        string bashex = bas.ToString("X");
                        if(bashex.ToString().Length==1)
                        {


                         bashex = "0" + bashex + "";
                         }
                        
                       if (ss.ToString().Length == 1)
                        {
                            hexValue = "04"+bashex+"0000000" + ss + "80";
                        }

                        if (ss.ToString().Length == 2)
                        {
                            hexValue = "04"+bashex+"000000" + ss + "80";
                        }

                        if (ss.ToString().Length == 3)
                        {
                            hexValue = "04" + bashex + "00000" + ss + "80";
                        }

                        if (ss.ToString().Length == 4)
                        {
                            hexValue = "04" + bashex + "0000" + ss + "80";
                        }

                        if (ss.ToString().Length == 5)
                        {
                            hexValue = "04" + bashex + "000" + ss + "80";
                        }

                        if (ss.ToString().Length == 6)
                        {
                            hexValue = "04" + bashex + "00" + ss + "80";
                        }

                        if (ss.ToString().Length == 7)
                        {
                            hexValue = "04" + bashex + "0" + ss + "80";
                        }

                        if (ss.ToString().Length == 8)
                        {
                            hexValue = "04" + bashex + "" + ss + "80";
                        }
                       
                         son = hexValue;
                        if (i % 10 == 0)
                        {
                            hexValue = "" + hexValue + "80";
                        }
                        else
                        {
                            hexValue = "" + hexValue + "00";
                        }
                        WriteHexStringToFile(hexValue, stream);
                    }                              
        }
        MessageBox.Show("IDler Başarıyla Eklendi");

        stream.Close();
      }
      catch (Exception ex)
      {
                MessageBox.Show(i.ToString());
        MessageBox.Show(ex.Message);
      }
       Chosen_File = "";
       button1.Visible=false;

        }

   

    private void WriteHexStringToFile(string hexString, FileStream stream)
    {
      var twoCharacterBuffer = new StringBuilder();
      var oneByte = new byte[1];
      foreach (var character in hexString.Where(c => c != ' '))
      {
        twoCharacterBuffer.Append(character);

        if (twoCharacterBuffer.Length == 2)
        {
          oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);

          stream.Write(oneByte, 0, 1);
          twoCharacterBuffer.Clear();
        }
      }
    }





    private void CreateFile(int durum)
    {
      try
      {

        if (durum==1)
        {

          rfu = "F0F0F0F0" + "01" + DateTime.Now.ToString("yyyyMMddHHmmss") + "00000000000000000000000000000000000000000400000000018080";

        }

        if (durum==0)
        {

          rfu = "F0F0F0F0" + "01" + DateTime.Now.ToString("yyyyMMddHHmmss") + "00000000000000000000000000000000000000000100000080";

        }

        


          


        try
        {
          using (BinaryWriter binWriter = new BinaryWriter(File.Open(fname, FileMode.Create)))
          {
            // Write string 
            var twoCharacterBuffer = new StringBuilder();
            var oneByte = new byte[1];
            foreach (var character in rfu.Where(c => c != ' '))
            {
              twoCharacterBuffer.Append(character);

              if (twoCharacterBuffer.Length == 2)
              {
                oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);

                binWriter.Write(oneByte, 0, 1);
                twoCharacterBuffer.Clear();
              }
            }



          }


        }
        catch (Exception)
        {

                    MessageBox.Show("Parametre Dosyası Oluşturulamadı");
        }









                MessageBox.Show("Parametre Dosyası Oluşturuldu :  "+ fname+"");






      }
      catch (Exception)
      {
        MessageBox.Show("Parametre Dosyası Oluşturulamadı");
      }




    }













    private void button2_Click(object sender, EventArgs e)
    {

      openFileDialog1.FileName = "";
      openFileDialog1.InitialDirectory = "C:";
      openFileDialog1.Title = "Hex Dosyasıını Seçiniz ";
      if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
      {

        MessageBox.Show("Dosya Seçilmedi");

      }
      else
      {

        Chosen_File = openFileDialog1.FileName;




        directory = Chosen_File.Substring(Chosen_File.LastIndexOf('\\'));


        if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111" || directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101" || directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
        {
          button1.BackColor = Color.Green;
          button1.Visible = true;
        }


      }


            

    }

    private void button3_Click(object sender, EventArgs e)
    {
          

          
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 5|| comboBox1.SelectedIndex == 10 || comboBox1.SelectedIndex == 15)
            {
                MessageBox.Show("Dosya Seçilmemiş");
            }
            else
            {

                if (comboBox1.SelectedIndex == 1)
                {
                    fname = @""+Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\FB303.300101";
                    durum = 0;
                    CreateFile(durum);

                }
                if (comboBox1.SelectedIndex == 2)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\FT303.300101";
                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 3)

                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FM305.300101";
                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 4)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FS305.300101";
                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 6)
                {

                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FB303.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 7)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FT303.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 8)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FM305.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 9)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FS305.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 11)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FB304.300101";

                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 12)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FT304.300101";
                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 13)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FM306.300101";
                    durum = 0;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 14)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FS306.300101";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 16)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FB304.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 17)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FT304.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 18)
                {

                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FM306.300111";
                    durum = 1;
                    CreateFile(durum);
                }
                if (comboBox1.SelectedIndex == 19)
                {
                    fname = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FS306.300111";
                    durum = 1;
                    CreateFile(durum);
                }


            }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      openFileDialog1.FileName = "";
      openFileDialog1.InitialDirectory = "C:";
      openFileDialog1.Title = "Hex Dosyasıını Seçiniz ";
      if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
      {

        MessageBox.Show("Dosya Seçilmedi");

      }
      else
      {
        

        Chosen_File = openFileDialog1.FileName;




        directory = Chosen_File.Substring(Chosen_File.LastIndexOf('\\'));


        if (directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101")
        {
          label4.Text = "Enter Desfire Card ID(4 Byte)";
          maskedTextBox2.Enabled = true;
          button5.Enabled = true;
          button6.Enabled = true;
          button6.BackColor = Color.Green;
          button5.BackColor = Color.Green;
        }
        if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111" || directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
        {
          label4.Text = "Enter UL Card ID(7 Byte)";
          maskedTextBox2.Enabled = true;
          button5.Enabled = true;
          button6.Enabled = true;
          button6.BackColor = Color.Green;
          button5.BackColor = Color.Green;
        }

      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      int value=0;
      
             if(comboBox2.SelectedIndex==0)
             {
                value = 80;
              }
                 if (comboBox2.SelectedIndex == 1)
              {
                value = 00;
              }
      int durum = 0;
           
            if (Chosen_File == "" || maskedTextBox2.Text.Length < 8 || comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Dosya Seçilmemiş , Kart Idsi Eksik yada Eklenecek Kartın Blacklist Durumu Belirtilmemiş Olabilir  ");
            }
            else
            {
                label8.Text = "CARD ID Ekleniyor Lütfen Bekleyiniz... ";    
                string ilksayi = maskedTextBox2.Text;
                char[] charArr = ilksayi.ToCharArray();
                string[] dizi1 = new string[16];
                for (int n = 0; n < charArr.Length; n++)
                {
                    string current = charArr[n].ToString();
                    dizi1[n] = current;
                }
                ilk_yaz = "" + dizi1[6] + "" + dizi1[7] + "" + dizi1[4] + "" + dizi1[5] + "" + dizi1[2] + "" + dizi1[3] + "" + dizi1[0] + "" + dizi1[1] +""+value+"";
                string ilksayi_ul = "" + dizi1[0] + "" + dizi1[1] + "" + dizi1[2] + "" + dizi1[3] + "" + dizi1[4] + "" + dizi1[5] + "" + dizi1[6] + "" + dizi1[7] + "" + dizi1[8] + "" + dizi1[9] + "" + dizi1[10] + "" + dizi1[11] + "" + dizi1[12] + "" + dizi1[13] + "" + dizi1[14] + "" + value + "";
                long intAgain = Int64.Parse(ilksayi, System.Globalization.NumberStyles.HexNumber);      
              intAgain = intAgain + 1;
               
                int hexIn;
                string fname_tmp = "";           
                FileStream fs = new FileStream(Chosen_File, FileMode.Open);
                fs.Position = 32;
                string yeni = Path.GetFileName(Chosen_File);
                if (directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101")
                {
                    fname_tmp = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\tmp.0300101";
                    if (maskedTextBox2.Text.Length == 8)
                    {
                        while (fs.Length > fs.Position)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                hexIn = fs.ReadByte();
                                dizi[i] = string.Format("{0:X2}", hexIn);
                            }                           
                            string ikincisayi = "" + dizi[3] + "" + "" + dizi[2] + "" + "" + dizi[1] + "" + "" + dizi[0] + "";
                            long sayi1 = Int64.Parse(ilksayi, System.Globalization.NumberStyles.HexNumber);                        
                            long sayi2 = Int64.Parse(ikincisayi, System.Globalization.NumberStyles.HexNumber);
                            if (  sayi1==sayi2)
                            {
                                label8.Text = "";
                                MessageBox.Show("Bu ID Bulunmaktadır  ve degeri : "+dizi[4]+"");
                                durum = 1;
                                break;
                            }
                                if (  sayi1 < sayi2)
                            {
                               
                                gecici = Path.GetFileName(Chosen_File);
                                MessageBox.Show(fname_tmp);
                                long yaz = fs.Position - 5;
                                fs.Position = 0;
                                try
                                {
                                    using (BinaryWriter binWriter =
                                    new BinaryWriter(File.Open(fname_tmp, FileMode.Create)))
                                    {

                                        while (fs.Length > fs.Position)
                                        {
                                            if (fs.Position == yaz)
                                            {                                            
                                                var twoCharacterBuffer = new StringBuilder();
                                                var oneByte = new byte[1];
                                                foreach (var character in ilk_yaz.Where(c => c != ' '))
                                                {
                                                    twoCharacterBuffer.Append(character);
                                                    if (twoCharacterBuffer.Length == 2)
                                                    {
                                                        oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                                                        binWriter.Write(oneByte, 0, 1);
                                                        twoCharacterBuffer.Clear();
                                                    }
                                                }

                                            }
                                            {
                                                {
                                                    hexIn = fs.ReadByte();
                                                    dizi[i] = string.Format("{0:X2}", hexIn);
                                                }
                                                string yaz_tmp = "" + dizi[0] + "" + "";
                                                var twoCharacterBuffer = new StringBuilder();
                                                var oneByte = new byte[1];
                                                foreach (var character in yaz_tmp.Where(c => c != ' '))
                                                {
                                                    twoCharacterBuffer.Append(character);

                                                    if (twoCharacterBuffer.Length == 2)
                                                    {
                                                        oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);

                                                        binWriter.Write(oneByte, 0, 1);
                                                        twoCharacterBuffer.Clear();
                                                    }
                                                }

                                            }





                                        }
                                        binWriter.Close();
                                    }

                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                                durum = 1;
                                gecici = Path.GetFileName(Chosen_File);
                                fs.Close();
                                File.Delete(Chosen_File);
                                File.Copy(fname_tmp, @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+ gecici + "");
                                label8.Text = "";
                                MessageBox.Show("Id Başarıyla Eklendi");
                               break;


                            }


                           

                        }
                       
                        if (durum==0)
                        {
                            
                           
                            
                           
                            long yaz = fs.Position;
                            
                            try
                            {
                               

                                    
                                            var twoCharacterBuffer = new StringBuilder();
                                            var oneByte = new byte[1];
                                            foreach (var character in ilk_yaz.Where(c => c != ' '))
                                            {
                                                twoCharacterBuffer.Append(character);
                                                if (twoCharacterBuffer.Length == 2)
                                                {
                                                    oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                                                    fs.Write(oneByte, 0, 1);
                                                    twoCharacterBuffer.Clear();
                                                }
                                            }

                                        
                                        





                                    
                                   
                                

                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            durum = 1;
                       
                         
                           
                         
                            MessageBox.Show("Id Başarıyla Eklendi");


                        }


                       








          }
                    else
                    {

                        MessageBox.Show("Card ID 4 Byte Olmalıdır");
                    }
                  
                     fs.Close();
        }
                if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111" || directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
                {
                    fname_tmp = @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\tmp.0300111";







                    if (maskedTextBox2.Text.Length == 14)
                    {
                        while (fs.Length > fs.Position)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                hexIn = fs.ReadByte();
                                dizi[i] = string.Format("{0:X2}", hexIn);
                            }
                            string ikincisayi = "" + dizi[0] + "" + dizi[1] + "" + dizi[2] + "" + dizi[3] + "" + dizi[4] + "" + dizi[5] + "" + dizi[6] + "";
                            long sayi1 = Int64.Parse(ilksayi, System.Globalization.NumberStyles.HexNumber);
                            long sayi2 = Int64.Parse(ikincisayi, System.Globalization.NumberStyles.HexNumber);
                            if (sayi1 == sayi2)
                            {
                                MessageBox.Show("Bu ID Bulunmaktadır  ve degeri : " + dizi[7] + "");
                                durum = 1;
                                break;
                            }
                            if (sayi1 < sayi2)
                            {
                                
                                gecici = Path.GetFileName(Chosen_File);
                                MessageBox.Show(fname_tmp);
                                long yaz = fs.Position - 8;
                                fs.Position = 0;
                                try
                                {
                                    using (BinaryWriter binWriter =
                                    new BinaryWriter(File.Open(fname_tmp, FileMode.Create)))
                                    {

                                        while (fs.Length > fs.Position)
                                        {
                                            if (fs.Position == yaz)
                                            {
                                                var twoCharacterBuffer = new StringBuilder();
                                                var oneByte = new byte[1];
                                                foreach (var character in ilksayi_ul.Where(c => c != ' '))
                                                {
                                                    twoCharacterBuffer.Append(character);
                                                    if (twoCharacterBuffer.Length == 2)
                                                    {
                                                        oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                                                        binWriter.Write(oneByte, 0, 1);
                                                        twoCharacterBuffer.Clear();
                                                    }
                                                }

                                            }
                                            {
                                                {
                                                    hexIn = fs.ReadByte();
                                                    dizi[i] = string.Format("{0:X2}", hexIn);
                                                }
                                                string yaz_tmp = "" + dizi[0] + "" + "";
                                                var twoCharacterBuffer = new StringBuilder();
                                                var oneByte = new byte[1];
                                                foreach (var character in yaz_tmp.Where(c => c != ' '))
                                                {
                                                    twoCharacterBuffer.Append(character);

                                                    if (twoCharacterBuffer.Length == 2)
                                                    {
                                                        oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);

                                                        binWriter.Write(oneByte, 0, 1);
                                                        twoCharacterBuffer.Clear();
                                                    }
                                                }

                                            }





                                        }
                                        binWriter.Close();
                                    }

                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                                durum = 1;
                                gecici = Path.GetFileName(Chosen_File);
                                fs.Close();
                                File.Delete(Chosen_File);
                                File.Copy(fname_tmp, @"" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + gecici + "");
                                MessageBox.Show("Id Başarıyla Eklendi");
                                break;

                                
                            }


                            

                        }
                       
                        if (durum == 0)
                        {




                            long yaz = fs.Position;

                            try
                            {



                                var twoCharacterBuffer = new StringBuilder();
                                var oneByte = new byte[1];
                                foreach (var character in ilksayi_ul.Where(c => c != ' '))
                                {
                                    twoCharacterBuffer.Append(character);
                                    if (twoCharacterBuffer.Length == 2)
                                    {
                                        oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                                        fs.Write(oneByte, 0, 1);
                                        twoCharacterBuffer.Clear();
                                    }
                                }












                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            durum = 1;



              
              MessageBox.Show("Id Başarıyla Eklendi");


                        }




                          






          }
                    else
                    {

                        MessageBox.Show("Card ID 7 Byte Olmalıdır");
                    }


































                    
          fs.Close();






        }
               





            }
         
            
        }

        private void button5_Click(object sender, EventArgs e)
    {
           

            if (Chosen_File=="" || maskedTextBox2.Text.Length<8)
            {
                MessageBox.Show("Dosya Seçilmemiş Yada Kart Idsi Eksik");
            }
             else
            {
               






            string ilksayi = maskedTextBox2.Text;


                char[] charArr = ilksayi.ToCharArray();
                string[] dizi1 = new string[16];
                for (int n = 0; n < charArr.Length; n++)
                {
                    string current = charArr[n].ToString();
                    dizi1[n] = current;

                }
              
                ilksayi = "" + dizi1[0] + "" + dizi1[1] + "" + dizi1[2] + "" + dizi1[3]+""+ dizi1[4] + "" + dizi1[5] + "" + dizi1[6] + "" + dizi1[7] + "";
               string ilksayi_ul= "" + dizi1[0] + "" + dizi1[1] + "" + dizi1[2] + "" + dizi1[3] + "" + dizi1[4] + "" + dizi1[5] + "" + dizi1[6] + "" + dizi1[7] +  "" + dizi1[8] + "" + dizi1[9] + "" + dizi1[10] + "" + dizi1[11] + "" + dizi1[12] + "" + dizi1[13] + "" + dizi1[14] + "";





                string ilk_yaz = ilksayi + "80";
            int hexIn;
     

            FileStream fs = new FileStream(Chosen_File, FileMode.Open);
            fs.Position = 32;
            string yeni = Path.GetFileName(Chosen_File);
            int state = 0;
          
            if (directory == "\\FB303.300101" || directory == "\\FT303.300101" || directory == "\\FM305.300101" || directory == "\\FS305.300101" || directory == "\\FB304.300101" || directory == "\\FT304.300101" || directory == "\\FM306.300101" || directory == "\\FS306.300101")
            {
                if (maskedTextBox2.Text.Length == 8)
                {
                        label9.Text = "CARD ID aranıyor Lütfen Bekleyiniz...";
                    while (fs.Length > fs.Position)
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            hexIn = fs.ReadByte();
                            dizi[i] = string.Format("{0:X2}", hexIn);

                        }
                        
                        string ikincisayi = "" + dizi[4] + "" + "" + dizi[3] + "" + "" + dizi[2] + "" + "" + dizi[1] + "";
                        long sayi1 = Int64.Parse(ilksayi, System.Globalization.NumberStyles.HexNumber);
                        

                        long sayi2 = Int64.Parse(ikincisayi, System.Globalization.NumberStyles.HexNumber);
                        if (sayi1 == sayi2)
                        {
                            
                         if (dizi[5] == "80")
                           {
                                    label9.Text = "";
                                    MessageBox.Show("Aranan ID Bulundu : " + maskedTextBox2.Text +  " Bu Kart :  BLACKLİSTTE ! ");
                         
                         }
                        if (dizi[5] == "00")
                         {
                                    label9.Text = "";
                                    MessageBox.Show("Aranan ID Bulundu : " + maskedTextBox2.Text + " Bu Kart :  BLACKLİSTTE  DEĞİL ! ");
                           
                         }
                         

        
                        
                            state = 0;
                              break;
  



                        }

                        if(sayi1<sayi2)
                            {
                                state = 1;
                                break;
                            }




                    }
                }
                else
                {

                    MessageBox.Show("Card ID 4 Byte Olmalıdır");
                }

                if (state == 1)
                {
                        label9.Text = "";
                        MessageBox.Show("Aranan ID Bulunamadı" );
                }
            }
           
            

            if (directory == "\\FB303.300111" || directory == "\\FT303.300111" || directory == "\\FM305.300111" || directory == "\\FS305.300111" || directory == "\\FB304.300111" || directory == "\\FT304.300111" || directory == "\\FM306.300111" || directory == "\\FS306.300111")
            {
                    fs.Position = 32;
                if (maskedTextBox2.Text.Length == 14)
                {
                        label9.Text = "CARD ID aranıyor Lütfen Bekleyiniz...";

                        while (fs.Length > fs.Position)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            hexIn = fs.ReadByte();
                            dizi[i] = string.Format("{0:X2}", hexIn);

                        }
                        fs.Position++;
                        string ikincisayi = "" + dizi[1] + "" + "" + dizi[2] + "" + "" + dizi[3] + "" + "" + dizi[4] + "" + "" + dizi[5] + "" + "" + dizi[6] + "" + "" + dizi[7] + "";
                        long sayi1 = Int64.Parse(ilksayi_ul, System.Globalization.NumberStyles.HexNumber);


                        long sayi2 = Int64.Parse(ikincisayi, System.Globalization.NumberStyles.HexNumber);
                        if (sayi1 == sayi2)
                        {
                                label9.Text = "";
                                MessageBox.Show("Aranan ID Bulundu : " + maskedTextBox2.Text+ "");
                            state = 1;
                           break;

                        }




                    }
                }
                else
                {

                    MessageBox.Show("Card ID 7 Byte Olmalıdır");
                }

                if (state == 0)
                {
                        label9.Text = "";
                        MessageBox.Show("Aranan ID Bulunamadı : " + maskedTextBox2.Text + "");
                }


            }





                fs.Close();


            }
            
        }

    
  }


}

   





