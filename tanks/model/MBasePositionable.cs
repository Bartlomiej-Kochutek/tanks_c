using tanks.common;

namespace tanks.model
{
    public abstract class MBasePositionable : IPositionable
    {
        private int mSize;




        public bool CollisionWithOtherPositinables(IPositionable iOtherObject)
        {
            if (iOtherObject == this)
                return false;

            if (Algorithm.IndicesOutsideWindow(this))
                return false;

            if (iOtherObject.GetPosX() > this.GetPosX() + this.GetSize() ||
                iOtherObject.GetPosX() + iOtherObject.GetSize() <= this.GetPosX() ||
                iOtherObject.GetPosY() > this.GetPosY() + this.GetSize() ||
                iOtherObject.GetPosY() + iOtherObject.GetSize() <= this.GetPosY())
                return false;

            return true;
        }



        public abstract int GetPosX();
        public abstract void SetPosX(int iPosX);

        public abstract int GetPosY();
        public abstract void SetPosY(int iPosY);

        public int GetSize()
        {
            return mSize;
        }
        public void SetSize(int iSize)
        {
            mSize = iSize;
        }

    }
}
