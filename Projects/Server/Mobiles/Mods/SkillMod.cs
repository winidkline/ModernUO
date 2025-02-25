/*************************************************************************
 * ModernUO                                                              *
 * Copyright 2019-2022 - ModernUO Development Team                       *
 * Email: hi@modernuo.com                                                *
 * File: SkillMod.cs                                                     *
 *                                                                       *
 * This program is free software: you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation, either version 3 of the License, or     *
 * (at your option) any later version.                                   *
 *                                                                       *
 * You should have received a copy of the GNU General Public License     *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *************************************************************************/

using System.Runtime.CompilerServices;
using ModernUO.Serialization;

namespace Server;

[SerializationGenerator(0)]
public abstract partial class SkillMod : MobileMod
{
    private bool _obeyCap;
    private bool _relative;
    private SkillName _skill;
    private double _value;

    public SkillMod(Mobile owner) : base(owner)
    {
    }

    public SkillMod(SkillName skill, bool relative, double value, Mobile owner = null) : base(owner)
    {
        _skill = skill;
        _relative = relative;
        _value = value;
    }

    [SerializableField(0)]
    public bool ObeyCap
    {
        get => _obeyCap;
        set
        {
            _obeyCap = value;

            var sk = Owner?.Skills[_skill];
            sk?.Update();
            MarkDirty();
        }
    }

    [SerializableField(1)]
    public SkillName Skill
    {
        get => _skill;
        set
        {
            if (_skill != value)
            {
                var oldUpdate = Owner?.Skills[_skill];

                _skill = value;

                var sk = Owner?.Skills[_skill];
                sk?.Update();
                oldUpdate?.Update();
                MarkDirty();
            }
        }
    }

    [SerializableField(2)]
    public bool Relative
    {
        get => _relative;
        set
        {
            if (_relative != value)
            {
                _relative = value;

                var sk = Owner?.Skills[_skill];
                sk?.Update();
                MarkDirty();
            }
        }
    }

    [SerializableField(3)]
    public bool Absolute
    {
        get => !_relative;
        set
        {
            if (_relative == value)
            {
                _relative = !value;

                var sk = Owner?.Skills[_skill];
                sk?.Update();
                MarkDirty();
            }
        }
    }

    [SerializableField(4)]
    public double Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;

                var sk = Owner?.Skills[_skill];
                sk?.Update();
                MarkDirty();
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Remove() => Owner?.RemoveSkillMod(this);

    public abstract bool CheckCondition();
}
