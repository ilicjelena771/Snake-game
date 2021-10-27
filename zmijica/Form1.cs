using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zmijica
{
    public partial class zmijica : Form
    {
        public zmijica()
        {
            InitializeComponent();
            zvuk.SoundLocation = "zvuk.wav";
        }
     /* u promenljivim gore, dole, levo, desno cuvamo informaciju koje dugme je korisnik
      * pritisnuo na tastaturi */   
        int gore = 0;
        int dole = 0;
        int levo = 0;
        int desno = 0;
        /* u promenljivoj score cuvamo broj osvojenih poena */
        int score = 0;
        String s = "Broj osvojenih poena: ";
        System.Media.SoundPlayer zvuk = new System.Media.SoundPlayer();
        
        /* promenljiva tipa random, trebace nam jer svaki put kada zmijica pojede hranu,
         hrana treba da se pojavi na nekom drugom slucajno izabranom mestu */
        Random r = new Random();
        /* lista picturebox-ova, svaki put kada zmijica pojede hranu, pravicemo novi
         * picturebox i dodavati ga u listu i nadovezati ga na zmijicu*/
        List<PictureBox> niz = new List<PictureBox>();
        PictureBox pomocna;

        /*metod koji pravi novi picturebox kada zmijica "pojede" hranu,a
         * hranu zatim stavljamo na neko drugo mesto */
        private void pravi()
        {
            int ind = 1;
            int i;
            pomocna = new PictureBox();
  /* kada zmijica "pojede" hranu, hranu cemo da stavimo na neko drugo mesto,
   * medjutim, moze da se desi da nova hrana bude na zmijici, a to ne zelimo
   * Ovaj deo koda proverava da li je hrana na zmijici. Ako jeste, hranu pomeramo
   * sve dok ne bude na nekom mestu koji nije na zmijici */          
            while (ind == 1)
            {
                hrana.Left = 20 * r.Next(0, 23);
                hrana.Top = 20 * r.Next(0, 23);
                /* kada smo pomerili hranu, proveravamo da li je hrana na zmijici
                 * ako jeste, ponovo pomerano hranu */
                for ( i = 0; i < niz.Count; i++)
                {
                    if (niz[i].Location == hrana.Location) 
                        break;      
                }
                /* ako smo prosli kroz celu zmijicu tj ako hrana nije na zmijici,
                 * postavljamo promenljivu ind na 0 i tako vise necemo prolaziti kroz while petlju */
                if (i == niz.Count)
                    ind = 0;
            }
            /* pravimo novi picture box, koji ce biti nadovezan na zmijicju */
            pomocna.Location = new Point(hrana.Left, hrana.Top);
            pomocna.Size = new Size(20, 20);
            pomocna.BackColor = Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255));
            this.Controls.Add(pomocna);
            niz.Add(pomocna);
        }
        private void greska()
        {
            /* kada zmijica udari u neku od ivica ili u sebe, igra se zavrsava,
             tajmer zaustavljamo, zmijica i hrana postaju nevidljivi, a backgroundimage
             je slika gameovr*/
            timer1.Stop();
            this.BackgroundImage = Image.FromFile(@"gameover.jpg");
            for (int i = 0; i < niz.Count; i++)
                niz[i].Visible = false;
            hrana.Visible = false;
            textBox1.Visible = false;
          DialogResult res = MessageBox.Show(textBox1.Text +"\nZelite li da igrate ponovo?", "Igra je zavrsena!",MessageBoxButtons.YesNo);
            niz.Clear();
            niz.Add(glava);
            if (res == DialogResult.Yes)
            {
                desno = 1;
                gore = 0;
                dole = 0;
                levo = 0;
                glava.Left = 40;
                glava.Top = 40;
                hrana.Left = 100;
                hrana.Top = 160;
                glava.Visible = true;
                hrana.Visible = true;
                this.BackgroundImage = null;
                score = 0;
                textBox1.Visible = true;
                textBox1.Text = s + score.ToString();
                timer1.Start();
                timer1.Interval = 200;

            }
            else
                Application.Exit();
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
/* hocemo da cuvamo informaciju koje dugme na tastaturi je korisik pritisnuo,
 * na osnovu toga znamo da li zmijica treba da se krece levo, desno, gore, ili dole */
 /* s obzirom na to je kraj igre kada zmijica udari u sebe, necemo da dozvolimo da je
  * moguce da npr zmijica promeni kretanje u levo ako vec ide desno  */           
            if (e.KeyData == Keys.Down)
            {
                if (gore == 0)
                {
                    dole = 1;
                    levo = 0;
                    desno = 0;
                }
            }
            if (e.KeyData == Keys.Up)
            {
                if (dole == 0)
                {
                    gore = 1;
                    levo = 0;
                    desno = 0;
                }
            }
            if (e.KeyData == Keys.Right)
            {
                if (levo == 0)
                {
                    desno = 1;
                    gore = 0;
                    dole = 0;
                }   
            }
            if (e.KeyData == Keys.Left)
            {
                if (desno == 0)
                {
                    levo = 1;
                    gore = 0;
                    dole = 0;
                }     
            }  
        }
        /* kroz ovaj metod cemo da pomeramo zmijicu */ 
        private void timer1_Tick(object sender, EventArgs e)
        {
          /* svaki element liste pomeramo na mesto prehodnog, a zatim pomeramo glavu */  
                for (int i = niz.Count - 1; i >=1; i--)
                {
                    niz[i].Location = niz[i-1].Location;
                   
                }
                /* prilikom pomeranja glave, proveravamo da li je glava udara u neku
                 * od ivica */
                if (dole == 1)
                {
                    niz[0].Top += 20;
                    if (glava.Top > 440)
                        greska();
                }
                if (gore == 1)
                {
                    niz[0].Top -= 20;
                    if (glava.Top < 0)
                        greska();
                }
                if (desno == 1)
                {
                    niz[0].Left += 20;
                    if (glava.Left > 460)
                        greska();
                }
                if (levo == 1)
                {
                    
                    niz[0].Left -= 20;
                    if (glava.Left < 0)
                        greska();
                }
                /* ako zmijica udari u sebe igra je zavrsena */
                for (int i = 1; i < niz.Count - 1; i++)
                if (niz[0].Location == niz[i].Location)
                {
                    timer1.Stop();
                        greska();
                }
                /* kada zmijica pojede hranu, hranu pomeramo na drugo mesto,
                 * pravimo novi picturebox, to radi fja pravi. Novi pictureBox ce biti
                 * nadovezan na zmijicu
                 * Povecamo broj poena i to upisujemo u textBox1 */
            if (niz[0].Location == hrana.Location)
            {
                zvuk.Play();
                pravi();
                score += 10;
                textBox1.Text = s + score.ToString();
                /* svaki put kada zmijica pojede hranu, hocemo da ubrzamo njeno kretanje */
                if (timer1.Interval-3 > 40) 
                {
                    timer1.Interval=timer1.Interval-3;
                }
            }         
        }

        private void zmijica_Load(object sender, EventArgs e)
        {
            /* kada se aplikacija ucita, glavu(crveni picturebox) koju smo napravili na
             * formi dodajemo u listu, koji se sastoji od picturebox-ova koji cine
             * nasu zmijicu */
           
            niz.Add(glava);
            /* textBox u koji cemo upisivati rezultat stavljamo na dnu forme */
            textBox1.Top = 460;
            textBox1.Text = "Broj osvojenih poena " + score.ToString();
            /* postavljamo da bude nevidljiv, postace vidljiv kada se zapocne igra */
            textBox1.Visible = false;
            /* kao sliku pozadine postavljemo sliku zmijice */
            this.BackgroundImage = Image.FromFile(@"zmija.jpg");

        }
/* igru zapocijemo klikom na dugme */
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
            /* kada igra zapocne, glava i hrana postaju vidljivi */
            glava.Visible = true;
            hrana.Visible = true;
            desno = 1;
            /* dugme postaje nevidljivo */
            button1.Visible = false;
            /* uklanjamo sliku pozadine */
            this.BackgroundImage = null;
            /* prikazuje se textBox u kom ce biti prikazani poeni */
            textBox1.Visible = true;
            /*onemogucujemo da upisivanje u taj textBox */
            textBox1.Enabled = false;
        }
    }
}
