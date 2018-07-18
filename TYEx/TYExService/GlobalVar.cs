using TYExDB;

namespace TYExService
{
    public static class GlobalVar
    {
        public static DbHelper DbHelper = new DbHelper("DbConnection");
    }
}
