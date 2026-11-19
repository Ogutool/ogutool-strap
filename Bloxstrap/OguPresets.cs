namespace Bloxstrap
{
    /// <summary>
    /// One-click fast flag presets for OguTool Strap.
    /// To add your own: add a new entry to <see cref="All"/> and a button in FastFlagsPage.xaml
    /// with Tag set to the preset's name.
    /// </summary>
    public static class OguPresets
    {
        private static readonly Dictionary<string, string> Common = new()
        {
            ["DFIntTaskSchedulerTargetFps"] = "9999",
            ["FFlagDebugGraphicsPreferD3D11"] = "True",
            ["DFIntMaxFrameBufferSize"] = "4",
            ["DFFlagDisableDPIScale"] = "True",
            ["FFlagAdServiceEnabled"] = "False",
            ["FFlagDebugDisableTelemetryEphemeralCounter"] = "True",
            ["FFlagDebugDisableTelemetryEphemeralStat"] = "True",
            ["FFlagDebugDisableTelemetryEventIngest"] = "True",
            ["FFlagDebugDisableTelemetryPoint"] = "True",
            ["FFlagDebugDisableTelemetryV2Counter"] = "True",
            ["FFlagDebugDisableTelemetryV2Event"] = "True",
            ["FFlagDebugDisableTelemetryV2Stat"] = "True",
            ["FIntRobloxGuiBlurIntensity"] = "0",
            ["FIntFullscreenTitleBarTriggerDelayMillis"] = "3600000",
            ["FIntCameraMaxZoomDistance"] = "9999",
            ["FFlagDebugDisplayFPS"] = "True",
        };

        private static readonly Dictionary<string, string> BestFps = new()
        {
            ["DFIntDebugFRMQualityLevelOverride"] = "1",
            ["FIntRenderShadowIntensity"] = "0",
            ["FFlagDisablePostFx"] = "True",
            ["FFlagGlobalWindRendering"] = "False",
            ["FFlagGlobalWindActivated"] = "False",
            ["FIntRenderLocalLightUpdatesMax"] = "8",
            ["FIntRenderLocalLightUpdatesMin"] = "6",
            ["FIntRenderLocalLightFadeInMs"] = "0",
            ["FFlagNewLightAttenuation"] = "True",
            ["FFlagFastGPULightCulling3"] = "True",
            ["FIntFRMMinGrassDistance"] = "0",
            ["FIntFRMMaxGrassDistance"] = "0",
            ["FIntRenderGrassDetailStrands"] = "0",
            ["FIntRenderGrassHeightScaler"] = "0",
            ["FIntTerrainArraySliceSize"] = "4",
            ["DFIntPerformanceControlTextureQualityBestUtility"] = "-1",
            ["DFIntCSGLevelOfDetailSwitchingDistance"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL12"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL23"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL34"] = "0",
            ["FIntDebugForceMSAASamples"] = "0",
        };

        private static readonly Dictionary<string, string> BestGraphics = new()
        {
            ["DFFlagTextureQualityOverrideEnabled"] = "True",
            ["DFIntTextureQualityOverride"] = "3",
            ["FIntDebugForceMSAASamples"] = "4",
            ["FFlagNewLightAttenuation"] = "True",
            ["FFlagFastGPULightCulling3"] = "True",
            ["FIntRenderShadowmapBias"] = "75",
        };

        private static readonly Dictionary<string, string> Potato = new()
        {
            ["DFIntDebugFRMQualityLevelOverride"] = "1",
            ["DFIntTextureQualityOverride"] = "0",
            ["DFFlagTextureQualityOverrideEnabled"] = "True",
            ["FIntRenderShadowIntensity"] = "0",
            ["FFlagDisablePostFx"] = "True",
            ["FFlagDebugSkyGray"] = "True",
            ["DFFlagDebugPauseVoxelizer"] = "True",
            ["FFlagGlobalWindRendering"] = "False",
            ["FFlagGlobalWindActivated"] = "False",
            ["FIntFRMMinGrassDistance"] = "0",
            ["FIntFRMMaxGrassDistance"] = "0",
            ["FIntRenderGrassDetailStrands"] = "0",
            ["FIntTerrainArraySliceSize"] = "4",
            ["DFIntCSGLevelOfDetailSwitchingDistance"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL12"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL23"] = "0",
            ["DFIntCSGLevelOfDetailSwitchingDistanceL34"] = "0",
            ["FIntDebugForceMSAASamples"] = "0",
        };

        private static Dictionary<string, string> Merge(params Dictionary<string, string>[] parts)
        {
            var result = new Dictionary<string, string>();
            foreach (var part in parts)
                foreach (var kv in part)
                    result[kv.Key] = kv.Value;
            return result;
        }

        public static readonly IReadOnlyDictionary<string, Dictionary<string, string>> All = new Dictionary<string, Dictionary<string, string>>
        {
            ["Best FPS"] = Merge(Common, BestFps),
            ["Best Graphics"] = Merge(Common, BestGraphics),
            ["Potato PC"] = Merge(Common, Potato),
            ["Essentials"] = Merge(Common),
        };

        /// <summary>Clears current flags and applies the named preset. Saved when the user presses Save.</summary>
        public static void Apply(string name)
        {
            if (!All.TryGetValue(name, out var flags))
                return;

            App.FastFlags.Prop.Clear();

            foreach (var kv in flags)
                App.FastFlags.SetValue(kv.Key, kv.Value);
        }
    }
}
