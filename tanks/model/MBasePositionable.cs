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

            if (iOtherObject.GetPosX() >= GetPosX() + GetSize() ||
                iOtherObject.GetPosX() + iOtherObject.GetSize() <= GetPosX() ||
                iOtherObject.GetPosY() >= GetPosY() + GetSize() ||
                iOtherObject.GetPosY() + iOtherObject.GetSize() <= GetPosY())
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
