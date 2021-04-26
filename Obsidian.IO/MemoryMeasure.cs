﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Obsidian.IO
{
    public static class MemoryMeasure
    {
        public const int GuidByteCount = 16;
        public const int AngleByteCount = 1;
        public const int VelocityByteCount = 6;
        public const int SoundPositionByteCount = 12;
        public const int PositionByteCount = 8;
        public const int AbsolutePositionByteCount = 24;

        private static readonly Encoding utf8 = Encoding.UTF8;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int GetByteCount<T>(T[] array) where T : unmanaged
        {
            return array.Length * sizeof(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int GetByteCount<T>(IList<T> list) where T : unmanaged
        {
            return list.Count * sizeof(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int GetByteCount<T>() where T : unmanaged
        {
            return sizeof(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetByteCount(string value)
        {
            return utf8.GetByteCount(value);
        }

        public static int GetVarIntByteCount(this int val)
        {
            int amount = 0;
            do
            {
                val >>= 7;
                amount++;
            } while (val != 0);

            return amount;
        }
    }
}
