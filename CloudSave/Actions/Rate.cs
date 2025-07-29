﻿using ConstructServices.Ratings.Enums;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Rate a cloud save
    /// </summary>
    [UsedImplicitly]
    public static RateResponse Rate(
        this CloudSaveService service,
        string sessionID,
        Guid cloudSaveID,
        Dictionary<string, byte> slotRatings)
    {
        const string path = "/rate.json";
        return Ratings.Actions.Rating.Rate(service, path, sessionID, RatableThing.CloudSaveBlob, cloudSaveID, slotRatings);
    }

    /// <summary>
    /// Rate a cloud save
    /// </summary>
    [UsedImplicitly]
    public static RateResponse Rate(
        this CloudSaveService service,
        string sessionID,
        Guid cloudSaveID,
        byte rating)
        => Rate(service, sessionID, cloudSaveID, new Dictionary<string, byte>{ { string.Empty, rating } });
}