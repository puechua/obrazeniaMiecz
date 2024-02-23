using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obrazeniaMiecz
{
    class SwordDamage
    {

        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;


        //usuniecie na rzecz wlasciwosci Roll
        //public int Roll;
        //private decimal magicMultiplier = 1M;
        //private int flamingDamage = 0;
        
        //na rzecz automatycznej wlasciwosci Damage
        //public int Damage;


        /// <summary>
        /// Obliczone obrażenia
        /// </summary>
        public int Damage { get; private set; }




        /// <summary>
        /// Ustawia lub pobiera wartość rzutu 3d6
        /// </summary>
        private int roll;

        public int Roll {
            get { return roll; }
            set {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// True jeśli miecz magiczny; w przeciwnym razie false
        /// </summary>
        private bool magic;

        public bool Magic {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            } 
        }

        /*
        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                magicMultiplier = 1.75M;
            }
            else
            {
                magicMultiplier = 1M;
            }
            CalculateDamage();
            Debug.WriteLine($"Po wykonaniu SetMagic: {Damage} (rzut: {Roll})");
        }
        */


        /// <summary>
        /// Zwraca true jeśli miecz płonący, w przeciwnym razie false
        /// </summary>
        private bool flaming;
        public bool Flaming {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            } 
        }

        /*
        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"Po wykonaniu SetFlaming: {Damage} (rzut: {Roll})");
        }
        */



        /// <summary>
        /// Oblicza obrazenia na podstawie aktualnych wartosci
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            //rzutowanie na int bo MagicMultiplier jest decimal
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            Debug.WriteLine($"Po wykonaniu CalculateDamage: {Damage} (rzut: {Roll})");

            if (Flaming) Damage += FLAME_DAMAGE;

        }



        /// <summary>
        /// Konstruktor oblicza obrazenia na podstawie DOMYSLNYCH wartosci dla Magic, Flaming i poczatkowego rzutu 3d6 (startingRoll)
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll){
            roll = startingRoll;
            CalculateDamage();
        }


    }
}
