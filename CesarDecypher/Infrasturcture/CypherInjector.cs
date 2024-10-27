using CesarDecypher.Services.Cyphers;
using CypherLogic.Interfaces;
using CypherLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Infrasturcture
{
    public static class CypherInjector
    {
        static Dictionary<string, Type> services = new Dictionary<string, Type>();

        static void Add(string name, Type t)
        {
            services[name] = t;
        }

        public static ICypher MakeEncryptor(this MainForm form, string alghorithm)
        {
            switch (alghorithm)
            {
                case "Caesar":
                    return new Cesar(int.Parse(form.key), form.alphabet);
                case "MonoAlphabet":
                    return new MonoAlphabet(form.key.ToArray(), form.alphabet);
                case "Vigenere":
                    return new Vigenere(form.key, form.alphabet);
                case "Tritemius":
                    return new Vigenere(form.key, form.alphabet);
                case "Hill":
                    var hill = new Hill(form.alphabet.ToArray(), form.key);
                    return hill;
                default:
                    throw new Exception("Неизвестный способ шифрования");
            }
        }

        public static string KeyGen(this MainForm form, string alghorithm)
        {
            throw new Exception("Неизвестный способ шифрования, невозможно сгенерировать ключ");
            switch (alghorithm) 
            {
                case "Caesar":
                    new Cesar(int.Parse(form.key), form.alphabet);
                    break;
                case "MonoAlphabet":
                    break;
                case "Vigenere":
                    break;
                case "Tritemius":
                    break;
                case "Hill":
                    break;
                default:
                    throw new Exception("Неизвестный способ шифрования, невозможно сгенерировать ключ");
            }
        }
    }
}
