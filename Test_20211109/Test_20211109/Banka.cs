using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_20211109
{
    public class Banka
    {
        public string jmeno;
        public float aktualniZustatek;

        public int max = 200000;
        public int tydenniLimit = 1000;
        public int platebniLimit = 5000;

        public float kontokorentLimit = -200;
        public bool kontokorent;

        public Banka(string jmeno, float aktualniZustatek)
        {
            this.jmeno = jmeno;
            this.aktualniZustatek = aktualniZustatek;
        }
        public void Vklad(float vklad)
        {
            if (vklad + aktualniZustatek <= max)
            {
                aktualniZustatek += vklad;
                MessageBox.Show("Bylo vloženo: " + vklad.ToString());
            }
            else if (vklad + aktualniZustatek >= max)
            {
                MessageBox.Show("Nepodařilo se vložit z důvodu překročení limitu");
                MessageBox.Show("Váš maximální limit je: " + max);
            }
        }
        public void Vypis()
        {
            MessageBox.Show("Aktuální zůstatek: " + aktualniZustatek + Environment.NewLine + "Týdenní limit: " + tydenniLimit + Environment.NewLine + "Platební limit: " + platebniLimit);
        }

        public void Vyber(float vyber)
        {

            if (vyber - aktualniZustatek <= 0 && vyber <= tydenniLimit)
            {
                aktualniZustatek -= vyber;
                MessageBox.Show("Bylo vybráno: " + vyber.ToString());
            }
            else if (vyber - aktualniZustatek > 0 && kontokorent == false)
            {
                MessageBox.Show("Nemáte dostatek na výběr z účtu");
            }
            else if (vyber - aktualniZustatek > kontokorentLimit && kontokorent == true)
            {
                aktualniZustatek -= vyber;
                MessageBox.Show("Bylo vybráno: " + vyber.ToString());
                if (aktualniZustatek <= kontokorentLimit)
                {
                    MessageBox.Show("Byl překročen imit");
                    aktualniZustatek = kontokorentLimit;
                }
            } 
            else
            {
                MessageBox.Show("Nepodařilo se vybrat, došlo k překročení týdenního limitu");
            }
        }
        public void Navyseni(int navyseni)
        {
            if (navyseni > tydenniLimit)
            {
                tydenniLimit = navyseni;
                MessageBox.Show("Navýšili jste svůj výběr na: " + tydenniLimit);
            }
            if (navyseni < tydenniLimit)
            {
                tydenniLimit = navyseni;
                MessageBox.Show("Zmenšili jste svůj výber na: " + tydenniLimit);
            }
        }
        public void NavyseniPlatby(int navyseni)
        {
            if (navyseni > platebniLimit)
            {
                platebniLimit = navyseni;
                MessageBox.Show("Navýšili jste svůj platební limit na: " + platebniLimit);
            }
            if (navyseni < platebniLimit)
            {
                platebniLimit = navyseni;
                MessageBox.Show("Zmenšili jste svůj platební limit na: " + platebniLimit);
            }
        }
        public void Platba (float platba)
        {
            if (platba - aktualniZustatek <= 0 && platba <= platebniLimit)
            {
                aktualniZustatek -= platba;
                MessageBox.Show("Transakce byla provedena"  + " s částkou:" + platba);
                MessageBox.Show("Aktualní zůstatek na účtě: " + aktualniZustatek);
            }
            else if (platba - aktualniZustatek > 0)
            {
                MessageBox.Show("Nemáte dostatek na provedení transakce");
            }
            else
            {
                MessageBox.Show("Nepodařilo se akci dokončit, došlo k překročení platebního limitu");
            }
        }
    }
}
