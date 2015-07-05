using System;

namespace Indexers
{
    class BitArray32class
    {
        private int number;

        //Constructor-validacia c constructora triabva da se izbiagva
        //V tozi sluchai ne e nujna validacia, tai kato podavame int, koito e 32 bitov
        public BitArray32class(int number)
        {
            this.number = number;
        }
        //Property- moje i tuk da se napravi validacia i e jelateno da e v setara, a ne v getara, zastoto se setvat greshni danni i chak kogato niakoi reshi da gi vika ot gettara se validiriat
        public int this[int index]// tuka moje da se podavat razlichni indexi na broi, moje dori i string, no pri izvikvane triabva da se izvikat sastite tipove
        {
            get { return this.GetBit(index); }
            set { this.SetBitAt(value, index);}// primerno ako bit[0]=1; value ste e 1(otdiasno na ravnoto), pri index 0
        }
        //Metod, koito prisvoiava daden bit na opredelen index s validacia
        public void SetBitAt(int bit, int index)
        {
            if (index < 0 || index > 31)
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is invalid!", index));
            }
            if (bit < 0 || bit > 1)
            {
                throw new ArgumentException(string.Format("Bit {0} is invalid!", bit));
            }
            this.number &= ~((1 << index));// Clear the bit at position index
            this.number |= (bit << index); // Set the bit at position index to value
        }
        
        //Method, bez indeksacia, po Javeshkia stil, s validacia
        public int GetBit(int index)
        {
            if (index < 0 || index > 31)
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is invalid!", index));
            }
            int bit = (this.number >> index) & 1;
            return bit;
        }
    }
}
