using System;
using System.Collections.Generic;
using System.Text;

namespace OwnDisposableObject
{
    class MyContainer : IDisposable
    {
        private MemoryStream memory = new MemoryStream();

        public void AddData(string text)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);

            memory.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            Console.WriteLine("CLeaning up the memory stream");

            memory.Dispose();
        }

    }
}
