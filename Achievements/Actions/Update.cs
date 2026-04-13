using ConstructServices.Achievements.Responses;
using ConstructServices.Common;
using ConstructServices.Common.Languages;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructServices.Achievements.Objects;
using ConstructServices.Common.Validations.Common;

namespace ConstructServices.Achievements;

public static partial class Actions
{
    extension(AchievementService service)
    {
        /// <summary>
        /// Update an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/update-achievement" />
        [UsedImplicitly]
        public AchievementResponse UpdateAchievement(Guid achievementID, UpdateAchievementOptions updateAchievementOptions)
        {
            var validation = updateAchievementOptions.Validate();
            if (!validation.Valid) return new AchievementResponse(validation.ErrorMessage);

            return Request.ExecuteMultiPartFormSyncRequest<AchievementResponse>(
                Config.EndPointPaths.Update,
                service,
                updateAchievementOptions.BuildFormData(achievementID),
                updateAchievementOptions.BuildBinaryFormData()
            );
        }
        
        /// <summary>
        /// Update an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/update-achievement" />
        [UsedImplicitly]
        public async Task<AchievementResponse> UpdateAchievementAsync(Guid achievementID, UpdateAchievementOptions updateAchievementOptions)
        {
            var validation = updateAchievementOptions.Validate();
            if (!validation.Valid) return new AchievementResponse(validation.ErrorMessage);

            return await Request.ExecuteMultiPartFormAsyncRequest<AchievementResponse>(
                Config.EndPointPaths.Update,
                service,
                updateAchievementOptions.BuildFormData(achievementID),
                updateAchievementOptions.BuildBinaryFormData()
            );
        }
    }    

    [UsedImplicitly]
    public sealed class UpdateAchievementOptions
    {
        [UsedImplicitly]
        public string Name { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }
        
        [UsedImplicitly]
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        [UsedImplicitly]
        public bool? ClientProgressAllowed { private get; set; }

        [UsedImplicitly]
        public bool? IsSecret { private get; set; }

        [UsedImplicitly]
        public int? MaxUnlocks { private get; set; }

        [UsedImplicitly]
        public long? ProgressionRequired { private get; set; }

        [UsedImplicitly]
        public List<XPBonus> XPBonuses { private get; set; }

        [UsedImplicitly]
        public PictureData UnachievedLogo { private get; set; }

        [UsedImplicitly]
        public PictureData AchievedLogo { private get; set; }
        
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            if (UnachievedLogo != null)
            {
                var pictureValidation = UnachievedLogo.IsPictureValid();
                if (!pictureValidation.Valid) return pictureValidation;
            }

            if (AchievedLogo != null)
            {
                var pictureValidation = AchievedLogo.IsPictureValid();
                if (!pictureValidation.Valid) return pictureValidation;
            }

            return new Common.Validations.Responses.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData(Guid achievementID)
        {
            var formData = new Dictionary<string, string>
            {
                { "achievementID", achievementID.ToString() }
            };
            
            if (Name != null)
            {
                formData.Add("name", Name);
            }
            if (Description != null)
            {
                formData.Add("description", Description);
            }
            if (LanguageISO != null)
            {
                formData.Add("language", LanguageISO);
            }
            if (ClientProgressAllowed.HasValue)
            {
                formData.Add("clientProgressAllowed", ClientProgressAllowed.Value.ToInt().ToString());
            }
            if (IsSecret.HasValue)
            {
                formData.Add("isSecret", IsSecret.Value.ToInt().ToString());
            }
            if (MaxUnlocks.HasValue)
            {
                formData.Add("maxUnlocks", MaxUnlocks.Value.ToString());
            }
            if (ProgressionRequired.HasValue && ProgressionRequired.Value != 0)
            {
                formData.Add("progressionRequired", ProgressionRequired.Value.ToString());
            }
            if (XPBonuses != null)
            {
                formData.Add("xpBonuses", string.Join(",", XPBonuses.Select(c=> c.From + "=" + c.Bonus)));
            }
            if (UnachievedLogo != null)
            {
                if (!string.IsNullOrWhiteSpace(UnachievedLogo.Base64))
                {
                    formData.Add("unachievedLogo", UnachievedLogo.Base64);
                }
                else if (UnachievedLogo.URL != null)
                {
                    formData.Add("unachievedLogoURL", UnachievedLogo.URL.ToString());
                }
            }
            if (AchievedLogo != null)
            {
                if (!string.IsNullOrWhiteSpace(AchievedLogo.Base64))
                {
                    formData.Add("achievedLogo", AchievedLogo.Base64);
                }
                else if (AchievedLogo.URL != null)
                {
                    formData.Add("achievedLogoURL", AchievedLogo.URL.ToString());
                }
            }

            return formData;
        }

        internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>();
            if (UnachievedLogo?.Bytes != null)
            {
                postedBinaryData.Add("unachievedLogoData", new ByteArrayContent(UnachievedLogo.Bytes));
            }
            if (AchievedLogo?.Bytes != null)
            {
                postedBinaryData.Add("achievedLogoData", new ByteArrayContent(AchievedLogo.Bytes));
            }
            return postedBinaryData;
        }
    }
}