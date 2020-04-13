namespace BuscaminasDefinitivo //Cambiar el nombre del namespace
{
    interface ICell
    {
        int GetValue();
        bool IsHidden();
        Celda.Status GetStatus();
        Celda.Status GetStatus1();

        void LeftClick();
        void RightClick();
    }
}