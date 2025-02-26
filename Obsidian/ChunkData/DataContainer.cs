﻿using Obsidian.Net;
using Obsidian.Utilities.Collection;

namespace Obsidian.ChunkData;
public abstract class DataContainer<T>
{
    public byte BitsPerEntry { get; }

    public abstract IPalette<T> Palette { get; internal set; }

    public abstract DataArray DataArray { get; protected set; }

    public DataContainer(byte bitsPerEntry) => this.BitsPerEntry = bitsPerEntry;

    public virtual int GetIndex(int x, int y, int z) => (y << this.BitsPerEntry | z) << this.BitsPerEntry | x;

    public abstract Task WriteToAsync(MinecraftStream stream);
    public abstract void WriteTo(MinecraftStream stream);
}
