using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guessingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string zadataRec;
        List<char> slovaKojaSuBila = new List<char>();  //lsita koja pamti slova koja su bila
        
        
        int brojPromasaja = 0;                          //broj promasaja je na pocetku nula

        private void Form1_Load(object sender, EventArgs e)
        {
            //kada se stranica ucita treba da se pojavi neka random rec u onom label-u na dnu


            //za pravu igricu bi ovde trebalo da se ubaci veliki broj razlicitih reci
            //ali da ne bih gubio vreme ubacicu samo nekoliko reci 
            List<string> skupSvihReci = new List<string>();

           skupSvihReci.Add("OTORINOLARINGOLOGIJA");  
            skupSvihReci.Add("PANORAMA");  
            skupSvihReci.Add("FAKS");  
            skupSvihReci.Add("MEMORIJA");  
            skupSvihReci.Add("KAFANA");  
            skupSvihReci.Add("ADOLESCENTCIJA");  
            skupSvihReci.Add("KORELACIJA");

            label2.Text = "";  


            //sada  biramo neku random rec od ovih ponudjenih

            Random ran = new Random();
            zadataRec = skupSvihReci[ran.Next(0, 6)];   //random od nula do 6.og indexa
              

            //sada se crtaju crtice i ako rec ima 10 slova onda se crta 10 crtica ,rec od 3 slova 3 crtice...

            label1.Text = "";   //stavljamo da kada se ucita program da je onaj dole label prazan na pocetku

            for(int i = 0; i<zadataRec.Length; i++)
            {
                label1.Text = label1.Text + "_ ";        //za svako slovo u reci po jedna crtica
            }


            //kada se ucita program na pocektu padajuca lista treba da se popuni sa svim mogucim slovima

            foreach(char slovo in "ABCČĆDEFGHIJKLMNOPRSTQŠUVWXYZŽ")
            {
                comboBox1.Items.Add(slovo);           //ovim smo dodali sva slova u opadajucu listu
            }




            //i treba da stavimo pocetnu sliku na pocetku kada se ucita program
            //Bitmap klasa se koristi kada hocemo da prikazemo neku sliku u c#

            pictureBox1.Image = new Bitmap("0.png");
                                              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dugme OK  

            //prvo moramo da proverimo koje je slovo korisnik odabrao i da li se nalazi u trazenoj reci


            char odabranoSlovo = comboBox1.Text[0];
           // izabranoSlovo = comboBox1.Text[0];

            if (zadataRec.Contains(odabranoSlovo) == false) //slucaj kada trazena rec ne sadrzi to slovo
            {
                brojPromasaja++;                           //tada se broj promasaja povecava za 1 
                pictureBox1.Image = new Bitmap(brojPromasaja + ".png");
                //i tada se menja slika tj dodaje se tipa noga,ruka i data su imena slika tako da ako je broj promasaja
                //1 onda ce da se prikaze slika broj 1 tj slika koja ima samo glavu,dva promasaja glava i ruka itd...

                if (brojPromasaja == 7)
                {
                    label2.Text = "END LOSER";   
                }
            
            
            }else
            {
                slovaKojaSuBila.Add(odabranoSlovo); 
                label1.Text = "";  //stavljamo label da je prazna pa cemo ponovo da dodamo crtice 
                                   //jer da ne stavimo sad label da je prazna onda bi se samo dodale crtice
                                   // na one stare crtice a to ne zelimo hocemo da ostane isto crtica
                                   // samo da se dodaju odabrana slova na njih

                for (int i = 0; i < zadataRec.Length; i++)
                {
                    if (slovaKojaSuBila.Contains(zadataRec[i])) {
                        
                        label1.Text = label1.Text + zadataRec[i] + " ";//onda dodaj u label slovo a ne crticu
                    }
                    else                                        //ako to slovo nije negde u trazenoj reci
                    {
                        label1.Text = label1.Text + "_ ";       //onda dodaj crticu u labe a ne slovo 
                    }
                }

            }


            if (label1.Text.Contains('_') == false)  //ako tekst ne sadrzi ni jednu crticu znaci da smo 
            {                                        //pobedili i da je kraj igre
                label2.Text = "WIN !!!"; 
            }

        }
    }
}
