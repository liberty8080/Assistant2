﻿using Assistant2.Models;

namespace Assistant2.Services.Magic;

public class MagicSubManager
{
    private List<MagicSubscribe> _subscribes = new();

    public List<MagicSubscribe> Subscribes { get; set; } = new();
}