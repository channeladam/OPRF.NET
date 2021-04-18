// ----------------------------------------------------------------------------
// <auto-generated>
// This is autogenerated code by CppSharp.
// Do not edit this file or all your changes will be lost after re-generation.
// </auto-generated>
// ----------------------------------------------------------------------------
using System.Runtime.InteropServices;
using System.Security;
using __CallingConvention = global::System.Runtime.InteropServices.CallingConvention;
using __IntPtr = global::System.IntPtr;

namespace Oprf.Net.Sodium
{
    public unsafe partial class core
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_init", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumInit();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_set_misuse_handler", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumSetMisuseHandler(__IntPtr handler);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_misuse", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumMisuse();
        }

        public static int SodiumInit()
        {
            var __ret = __Internal.SodiumInit();
            return __ret;
        }

        public static int SodiumSetMisuseHandler(global::Oprf.Net.Sodium.Delegates.Action_ handler)
        {
            var __arg0 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            var __ret = __Internal.SodiumSetMisuseHandler(__arg0);
            return __ret;
        }

        public static void SodiumMisuse()
        {
            __Internal.SodiumMisuse();
        }
    }

    public unsafe partial class utils
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_memzero", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumMemzero(__IntPtr pnt, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_stackzero", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumStackzero(ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_memcmp", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMemcmp(__IntPtr b1_, __IntPtr b2_, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_compare", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumCompare(byte* b1_, byte* b2_, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_is_zero", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumIsZero(byte* n, ulong nlen);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_increment", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumIncrement(byte* n, ulong nlen);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_add", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumAdd(byte* a, byte* b, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_sub", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumSub(byte* a, byte* b, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_bin2hex", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern sbyte* SodiumBin2hex(sbyte* hex, ulong hex_maxlen, byte* bin, ulong bin_len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_hex2bin", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumHex2bin(byte* bin, ulong bin_maxlen, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))] string hex, ulong hex_len, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))] string ignore, ulong* bin_len, sbyte** hex_end);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_base64_encoded_len", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong SodiumBase64EncodedLen(ulong bin_len, int variant);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_bin2base64", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern sbyte* SodiumBin2base64(sbyte* b64, ulong b64_maxlen, byte* bin, ulong bin_len, int variant);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_base642bin", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumBase642bin(byte* bin, ulong bin_maxlen, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))] string b64, ulong b64_len, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))] string ignore, ulong* bin_len, sbyte** b64_end, int variant);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_mlock", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMlock(__IntPtr addr, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_munlock", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMunlock(__IntPtr addr, ulong len);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_malloc", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern __IntPtr SodiumMalloc(ulong size);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_allocarray", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern __IntPtr SodiumAllocarray(ulong count, ulong size);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_free", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void SodiumFree(__IntPtr ptr);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_mprotect_noaccess", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMprotectNoaccess(__IntPtr ptr);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_mprotect_readonly", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMprotectReadonly(__IntPtr ptr);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_mprotect_readwrite", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumMprotectReadwrite(__IntPtr ptr);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_pad", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumPad(ulong* padded_buflen_p, byte* buf, ulong unpadded_buflen, ulong blocksize, ulong max_buflen);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_unpad", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumUnpad(ulong* unpadded_buflen_p, byte* buf, ulong padded_buflen, ulong blocksize);

            [SuppressUnmanagedCodeSecurity, DllImport("Oprf.Net.Sodium", EntryPoint = "_sodium_alloc_init", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumAllocInit();
        }

        public static void SodiumMemzero(__IntPtr pnt, ulong len)
        {
            __Internal.SodiumMemzero(pnt, len);
        }

        public static void SodiumStackzero(ulong len)
        {
            __Internal.SodiumStackzero(len);
        }

        public static int SodiumMemcmp(__IntPtr b1_, __IntPtr b2_, ulong len)
        {
            var __ret = __Internal.SodiumMemcmp(b1_, b2_, len);
            return __ret;
        }

        public static int SodiumCompare(byte* b1_, byte* b2_, ulong len)
        {
            var __ret = __Internal.SodiumCompare(b1_, b2_, len);
            return __ret;
        }

        public static int SodiumIsZero(byte* n, ulong nlen)
        {
            var __ret = __Internal.SodiumIsZero(n, nlen);
            return __ret;
        }

        public static void SodiumIncrement(byte* n, ulong nlen)
        {
            __Internal.SodiumIncrement(n, nlen);
        }

        public static void SodiumAdd(byte* a, byte* b, ulong len)
        {
            __Internal.SodiumAdd(a, b, len);
        }

        public static void SodiumSub(byte* a, byte* b, ulong len)
        {
            __Internal.SodiumSub(a, b, len);
        }

        public static sbyte* SodiumBin2hex(sbyte* hex, ulong hex_maxlen, byte* bin, ulong bin_len)
        {
            var __ret = __Internal.SodiumBin2hex(hex, hex_maxlen, bin, bin_len);
            return __ret;
        }

        public static int SodiumHex2bin(byte* bin, ulong bin_maxlen, string hex, ulong hex_len, string ignore, ref ulong bin_len, sbyte** hex_end)
        {
            fixed (ulong* __bin_len5 = &bin_len)
            {
                var __arg5 = __bin_len5;
                var __ret = __Internal.SodiumHex2bin(bin, bin_maxlen, hex, hex_len, ignore, __arg5, hex_end);
                return __ret;
            }
        }

        public static ulong SodiumBase64EncodedLen(ulong bin_len, int variant)
        {
            var __ret = __Internal.SodiumBase64EncodedLen(bin_len, variant);
            return __ret;
        }

        public static sbyte* SodiumBin2base64(sbyte* b64, ulong b64_maxlen, byte* bin, ulong bin_len, int variant)
        {
            var __ret = __Internal.SodiumBin2base64(b64, b64_maxlen, bin, bin_len, variant);
            return __ret;
        }

        public static int SodiumBase642bin(byte* bin, ulong bin_maxlen, string b64, ulong b64_len, string ignore, ref ulong bin_len, sbyte** b64_end, int variant)
        {
            fixed (ulong* __bin_len5 = &bin_len)
            {
                var __arg5 = __bin_len5;
                var __ret = __Internal.SodiumBase642bin(bin, bin_maxlen, b64, b64_len, ignore, __arg5, b64_end, variant);
                return __ret;
            }
        }

        public static int SodiumMlock(__IntPtr addr, ulong len)
        {
            var __ret = __Internal.SodiumMlock(addr, len);
            return __ret;
        }

        public static int SodiumMunlock(__IntPtr addr, ulong len)
        {
            var __ret = __Internal.SodiumMunlock(addr, len);
            return __ret;
        }

        public static __IntPtr SodiumMalloc(ulong size)
        {
            var __ret = __Internal.SodiumMalloc(size);
            return __ret;
        }

        public static __IntPtr SodiumAllocarray(ulong count, ulong size)
        {
            var __ret = __Internal.SodiumAllocarray(count, size);
            return __ret;
        }

        public static void SodiumFree(__IntPtr ptr)
        {
            __Internal.SodiumFree(ptr);
        }

        public static int SodiumMprotectNoaccess(__IntPtr ptr)
        {
            var __ret = __Internal.SodiumMprotectNoaccess(ptr);
            return __ret;
        }

        public static int SodiumMprotectReadonly(__IntPtr ptr)
        {
            var __ret = __Internal.SodiumMprotectReadonly(ptr);
            return __ret;
        }

        public static int SodiumMprotectReadwrite(__IntPtr ptr)
        {
            var __ret = __Internal.SodiumMprotectReadwrite(ptr);
            return __ret;
        }

        public static int SodiumPad(ref ulong padded_buflen_p, byte* buf, ulong unpadded_buflen, ulong blocksize, ulong max_buflen)
        {
            fixed (ulong* __padded_buflen_p0 = &padded_buflen_p)
            {
                var __arg0 = __padded_buflen_p0;
                var __ret = __Internal.SodiumPad(__arg0, buf, unpadded_buflen, blocksize, max_buflen);
                return __ret;
            }
        }

        public static int SodiumUnpad(ref ulong unpadded_buflen_p, byte* buf, ulong padded_buflen, ulong blocksize)
        {
            fixed (ulong* __unpadded_buflen_p0 = &unpadded_buflen_p)
            {
                var __arg0 = __unpadded_buflen_p0;
                var __ret = __Internal.SodiumUnpad(__arg0, buf, padded_buflen, blocksize);
                return __ret;
            }
        }

        public static int SodiumAllocInit()
        {
            var __ret = __Internal.SodiumAllocInit();
            return __ret;
        }
    }

    public unsafe partial class crypto_core_ristretto255
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_bytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoCoreRistretto255Bytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_hashbytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoCoreRistretto255Hashbytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalarbytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoCoreRistretto255Scalarbytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_nonreducedscalarbytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoCoreRistretto255Nonreducedscalarbytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_is_valid_point", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoCoreRistretto255IsValidPoint(byte* p);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_add", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoCoreRistretto255Add(byte* r, byte* p, byte* q);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_sub", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoCoreRistretto255Sub(byte* r, byte* p, byte* q);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_from_hash", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoCoreRistretto255FromHash(byte* p, byte* r);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_random", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255Random(byte* p);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_random", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarRandom(byte* r);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_invert", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoCoreRistretto255ScalarInvert(byte* recip, byte* s);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_negate", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarNegate(byte* neg, byte* s);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_complement", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarComplement(byte* comp, byte* s);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_add", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarAdd(byte* z, byte* x, byte* y);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_sub", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarSub(byte* z, byte* x, byte* y);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_mul", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarMul(byte* z, byte* x, byte* y);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_core_ristretto255_scalar_reduce", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void CryptoCoreRistretto255ScalarReduce(byte* r, byte* s);
        }

        public static ulong CryptoCoreRistretto255Bytes()
        {
            var __ret = __Internal.CryptoCoreRistretto255Bytes();
            return __ret;
        }

        public static ulong CryptoCoreRistretto255Hashbytes()
        {
            var __ret = __Internal.CryptoCoreRistretto255Hashbytes();
            return __ret;
        }

        public static ulong CryptoCoreRistretto255Scalarbytes()
        {
            var __ret = __Internal.CryptoCoreRistretto255Scalarbytes();
            return __ret;
        }

        public static ulong CryptoCoreRistretto255Nonreducedscalarbytes()
        {
            var __ret = __Internal.CryptoCoreRistretto255Nonreducedscalarbytes();
            return __ret;
        }

        public static int CryptoCoreRistretto255IsValidPoint(byte* p)
        {
            var __ret = __Internal.CryptoCoreRistretto255IsValidPoint(p);
            return __ret;
        }

        public static int CryptoCoreRistretto255Add(byte* r, byte* p, byte* q)
        {
            var __ret = __Internal.CryptoCoreRistretto255Add(r, p, q);
            return __ret;
        }

        public static int CryptoCoreRistretto255Sub(byte* r, byte* p, byte* q)
        {
            var __ret = __Internal.CryptoCoreRistretto255Sub(r, p, q);
            return __ret;
        }

        public static int CryptoCoreRistretto255FromHash(byte* p, byte* r)
        {
            var __ret = __Internal.CryptoCoreRistretto255FromHash(p, r);
            return __ret;
        }

        public static void CryptoCoreRistretto255Random(byte* p)
        {
            __Internal.CryptoCoreRistretto255Random(p);
        }

        public static void CryptoCoreRistretto255ScalarRandom(byte* r)
        {
            __Internal.CryptoCoreRistretto255ScalarRandom(r);
        }

        public static int CryptoCoreRistretto255ScalarInvert(byte* recip, byte* s)
        {
            var __ret = __Internal.CryptoCoreRistretto255ScalarInvert(recip, s);
            return __ret;
        }

        public static void CryptoCoreRistretto255ScalarNegate(byte* neg, byte* s)
        {
            __Internal.CryptoCoreRistretto255ScalarNegate(neg, s);
        }

        public static void CryptoCoreRistretto255ScalarComplement(byte* comp, byte* s)
        {
            __Internal.CryptoCoreRistretto255ScalarComplement(comp, s);
        }

        public static void CryptoCoreRistretto255ScalarAdd(byte* z, byte* x, byte* y)
        {
            __Internal.CryptoCoreRistretto255ScalarAdd(z, x, y);
        }

        public static void CryptoCoreRistretto255ScalarSub(byte* z, byte* x, byte* y)
        {
            __Internal.CryptoCoreRistretto255ScalarSub(z, x, y);
        }

        public static void CryptoCoreRistretto255ScalarMul(byte* z, byte* x, byte* y)
        {
            __Internal.CryptoCoreRistretto255ScalarMul(z, x, y);
        }

        public static void CryptoCoreRistretto255ScalarReduce(byte* r, byte* s)
        {
            __Internal.CryptoCoreRistretto255ScalarReduce(r, s);
        }
    }

    public unsafe partial class crypto_scalarmult_ristretto255
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_scalarmult_ristretto255_bytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoScalarmultRistretto255Bytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_scalarmult_ristretto255_scalarbytes", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern ulong CryptoScalarmultRistretto255Scalarbytes();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_scalarmult_ristretto255", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoScalarmultRistretto255(byte* q, byte* n, byte* p);

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "crypto_scalarmult_ristretto255_base", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int CryptoScalarmultRistretto255Base(byte* q, byte* n);
        }

        public static ulong CryptoScalarmultRistretto255Bytes()
        {
            var __ret = __Internal.CryptoScalarmultRistretto255Bytes();
            return __ret;
        }

        public static ulong CryptoScalarmultRistretto255Scalarbytes()
        {
            var __ret = __Internal.CryptoScalarmultRistretto255Scalarbytes();
            return __ret;
        }

        public static int CryptoScalarmultRistretto255(byte* q, byte* n, byte* p)
        {
            var __ret = __Internal.CryptoScalarmultRistretto255(q, n, p);
            return __ret;
        }

        public static int CryptoScalarmultRistretto255Base(byte* q, byte* n)
        {
            var __ret = __Internal.CryptoScalarmultRistretto255Base(q, n);
            return __ret;
        }
    }

    public unsafe partial class version
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_version_string", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern __IntPtr SodiumVersionString();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_library_version_major", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumLibraryVersionMajor();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_library_version_minor", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumLibraryVersionMinor();

            [SuppressUnmanagedCodeSecurity, DllImport("sodium", EntryPoint = "sodium_library_minimal", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern int SodiumLibraryMinimal();
        }

        public static string SodiumVersionString()
        {
            var __ret = __Internal.SodiumVersionString();
            return CppSharp.Runtime.MarshalUtil.GetString(global::System.Text.Encoding.UTF8, __ret);
        }

        public static int SodiumLibraryVersionMajor()
        {
            var __ret = __Internal.SodiumLibraryVersionMajor();
            return __ret;
        }

        public static int SodiumLibraryVersionMinor()
        {
            var __ret = __Internal.SodiumLibraryVersionMinor();
            return __ret;
        }

        public static int SodiumLibraryMinimal()
        {
            var __ret = __Internal.SodiumLibraryMinimal();
            return __ret;
        }
    }

    namespace Delegates
    {
        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(__CallingConvention.Cdecl)]
        public unsafe delegate void Action_();
    }
}
