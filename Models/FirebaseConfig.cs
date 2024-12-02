using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace HappyCakes.Models
{
    public class FirebaseConfig
    {
        public IFirebaseConfig Config { get; private set; }
        public IFirebaseClient Client { get; private set; }

        public FirebaseConfig()
        {
            Config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = @"nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCoKdHrIatprn8c\nze1yfjXfetLBrETbNTRCA6I8M/+H9x76KFj+lxd1ZL++4QAPqcq3aCcuW7pwbhAj\nqZJhJDRNGxM/1U+UNv04BaVXO8ew+nFKRpGQeroCmpy3F2ldf/gE6xajwMgEZAmp\naQtS+6x25JRyRe9OVTnBiWyHPYYZN11s+V8c0KEFdhB2nSNXQqqDlmjNXuESolKv\nw69/f3CDVvuEWY8Tw97Ydnwrc5UY5mlZpoudiuTa5G8NOu8f36jKrspCvpgGwidj\nhiCB87AirGHxfpSxcx2LfxMYDYCDYvc3goR+UezwTqPoHQVnsNPi5E5SkhRYi5o2\nBSOEVgrhAgMBAAECggEAAypsYP6MhUwLaQ2oYW4mUft0McCuOCk3f2GloXgCILti\neiedy0cpYiSgJnYCZAkYf5zmle0UpK6xv5Ye4xTFJkly8pHvslTZrf8PNoXx069X\nSCRtc5iX3VovRpQaf+/bia4qSjFkIo8GjomjdK+3trJFaCRQZbtdf7r4T9B08I8O\nLasXLnlCwyWSJbdYffG0a1H+PivffeE/tVe445zcyGP0DSLCN0dWXrzcRW0DhttA\nwUZ8xBqm+4vPDatCi5S0Nk4uylmT7S/Z0V35zVYwiY1mtXT314Jzu+LRGHCfl2B6\nJl8+R9lXlpfxzNfdIM4NHvcM2NlOpc9ypFL5zJcWAQKBgQDgDCaKBHrzhHzcwqCY\nTmQg/KwNu+DwfO5NPq7+jbUtKVZ3vUvKdCezB8alXgh6RBes+dJXFJCcz4xeW/Zx\nmShMsICycioeIK/Xy9rF4QJVhUrF0W1QpazlYc636oQrXmkvGZ+qh8QaA+NBYlZ/\npWKtXLZoftPgTxL7iy34VVkMoQKBgQDAJV8hwIX5xz72vjULAB0S/SfDCtP3LBbF\nkL0URCqQR9lPUGeX5mhRW0yZ/4WSEMSmKo431gcuHipybal/RWgWOb3RJ7RSUMV7\n5lqM7xE7IPKLZjd8soqQsbFlwkRIBSmatMJLZKhliKiD0W0Y1vdGvBfWmNVkTsFo\n0TP/iyQWQQKBgBiIPBAQvYW8lA94IC2NJ9mU0SIP2Gl8xHsgyfiFe7keNaGW0J2y\nakZoK5Af472/hvghwq5WSh9henU6jJmTs53yFaV0argxzA9M+v9/y8mhdraCX/3c\npjnXo9LvktlM1SebHqiFhSt0EYYvRlljupJQ/Igkmv6Mqf9xFe+DKOUBAoGBALn6\n8kuvF36e1ljp3lmZcIrSskvdDTGvYRM1d25IVJJ2mOZmQv8KK2qj3k8ovlaVGGJl\nymZNKYH//MHpVygzO/5XQV1S+vy55Yx5eKf1Nk5vI5S+CXMPNYO8GqMOGB1FsfFm\niLGE6mHsln+Qk/J5D7tNkB1MrS9780TLSXNNcE6BAoGBAIo5c3XqjDi3Yxlmblh1\nDJmpILJAwTM5bookmC4s48YWeOZqB0H/DpycSV2FDgONm1xjTdoea1CkkibcFEsh\n+6eXijl/IGAeKdzA61A9Fkkce2J0vD0dqeaKQT39KxGPHeWh3nYxJGEYlNzn1bfm\nr6vH3C7YL2O4cNI+eLRnydNk",
                BasePath = "https://happycakes-14f04-default-rtdb.firebaseio.com/" 
            };

            Client = new FireSharp.FirebaseClient(Config);
            if (Client == null)
            {
                throw new Exception("Não foi possível conectar ao Firebase.");
            }
        }
    }
}
