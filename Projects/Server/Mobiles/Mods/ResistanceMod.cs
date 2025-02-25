/*************************************************************************
 * ModernUO                                                              *
 * Copyright 2019-2022 - ModernUO Development Team                       *
 * Email: hi@modernuo.com                                                *
 * File: ResistanceMod.cs                                                *
 *                                                                       *
 * This program is free software: you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation, either version 3 of the License, or     *
 * (at your option) any later version.                                   *
 *                                                                       *
 * You should have received a copy of the GNU General Public License     *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *************************************************************************/

using ModernUO.Serialization;

namespace Server;

[SerializationGenerator(0)]
public partial class ResistanceMod : MobileMod
{
    // Field 0
    private int _offset;

    // Field 1
    private ResistanceType _type;

    public ResistanceMod(Mobile owner) : base(owner)
    {
    }

    public ResistanceMod(ResistanceType type, int offset, Mobile owner = null) : base(owner)
    {
        _type = type;
        _offset = offset;
    }

    [SerializableField(0)]
    public ResistanceType Type
    {
        get => _type;
        set
        {
            if (_type != value)
            {
                _type = value;

                Owner?.UpdateResistances();
                MarkDirty();
            }
        }
    }

    [SerializableField(1)]
    public int Offset
    {
        get => _offset;
        set
        {
            if (_offset != value)
            {
                _offset = value;

                Owner?.UpdateResistances();
                MarkDirty();
            }
        }
    }
}
