using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Common.Common
{
    public class StructToShortTool
    {
        //// <summary>               
        /// 结构体转short数组         
        /// </summary>               
        /// <param name="structObj">要9转换的结构体</param>
        /// <returns>转换后的short数组</returns>
        public static short[] StructToShort(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj) / 2;
            //创建byte数组
            //byte[] bytes = new byte[size];
            short[] shorts = new short[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            //Marshal.Copy(structPtr, bytes, 0, size);
            Marshal.Copy(structPtr, shorts, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return shorts;
        }

        public static byte[] StructToByte(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }

        /// <summary>
        /// short数组转结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">结构体类型</param>
        /// <returns>转换后的结构体</returns>
        public static object ShortToStuct(short[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type) / 2;
            //byte数组长度小于结构体的大小
            if (size != bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

        public static object ByteToStuct(byte[] bytes, int offset, int length, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size != length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, offset, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

        /// <summary>
        /// 无符号转有符号
        /// </summary>
        /// <param name="ushorts"></param>
        /// <returns></returns>
        public static short[] UshortsToshorts(ushort[] ushorts)
        {
            //return ushorts.Select(Convert.ToInt16).ToArray();
            short[] datas = new short[ushorts.Length];
            for(int i=0;i<ushorts.Length;i++)
            {
                datas[i] = (short)ushorts[i];
            }
            return datas;
        }
        /// <summary>
        /// 有符号转无符号
        /// </summary>
        /// <param name="shorts"></param>
        /// <returns></returns>
        public static ushort[] shortsToUshorts(short[] shorts)
        {
            //return shorts.Select(Convert.ToUInt16).ToArray();
            ushort[] datas = new ushort[shorts.Length];
            for (int i = 0; i < shorts.Length; i++)
            {
                datas[i] = (ushort)shorts[i];
            }
            return datas;
        }
    }
}
