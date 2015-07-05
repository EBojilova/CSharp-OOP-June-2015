using System;

struct BitArray32 // ne e class a struct
{
    public const int BitsCount = 32;

    private uint bitValues;

    //Property- nesto sredno mejdu metod i property
    public int this[int index] //Indexer declaration s this otpred
    {
        get
        {
            if (0 <= index && index < BitsCount)
            {
                if ((this.bitValues & (1 << index)) == 0) // Check the bit at position index
                {
                    return 0;//izlizame ot get
                }
                return 1;//izlizame ot get
            }
            throw new IndexOutOfRangeException(string.Format("Index {0} is invalid!",index));
        }
        set
        {
            if (index < 0 || index > BitsCount - 1)
            {
                throw new IndexOutOfRangeException(string.Format( "Index {0} is invalid!",index));
            }
            if (value < 0 || value > 1)
            {
                throw new ArgumentException(string.Format("Value {0} is invalid!",value));
            }
            this.bitValues &= ~((uint)(1 << index));// Clear the bit at position index
            this.bitValues |= (uint)(value << index); // Set the bit at position index to value
        }
    }
}