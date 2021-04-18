//
// Originally copied from https://github.com/mono/CppSharp/blob/main/src/Runtime/UTF8Marshaller.cs
//

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CppSharp.Runtime
{
    // HACK: .NET Standard 2.0 which we use in auto-building to support .NET Framework, lacks UnmanagedType.LPUTF8Str
    public class UTF8Marshaller : ICustomMarshaler
    {
        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
            => Marshal.FreeHGlobal(pNativeData);

        public int GetNativeDataSize() => -1;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj == null)
            {
                return IntPtr.Zero;
            }

            if (ManagedObj is not string)
            {
                throw new MarshalDirectiveException(
                    "UTF8Marshaler must be used on a string.");
            }

            // not null terminated
            byte[] strbuf = Encoding.UTF8.GetBytes((string)ManagedObj);
            IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length + 1);
            Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

            // write the terminating null
            Marshal.WriteByte(buffer + strbuf.Length, 0);
            return buffer;
        }

        public unsafe object MarshalNativeToManaged(IntPtr str)
        {
            if (str == IntPtr.Zero)
            {
                return string.Empty;
            }

            int byteCount = 0;
            var str8 = (byte*)str;
            while (*(str8++) != 0)
            {
                byteCount += sizeof(byte);
            }

            return Encoding.UTF8.GetString((byte*)str, byteCount);
        }

        public static ICustomMarshaler GetInstance(string pstrCookie) => _marshaler ??= new UTF8Marshaller();

        private static UTF8Marshaller? _marshaler;
    }
}
