namespace CosAdmin
{
    public class Common
    {
        public static string GetKeyStatus(int index)
        {
            switch (index)
            {
                case 0:
                    return "7";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "90";
                case 4:
                    return "180";
                case 5:
                    return "360";
                case 6:
                    return "999999";
            }
            return string.Empty;
        }
    }
}
