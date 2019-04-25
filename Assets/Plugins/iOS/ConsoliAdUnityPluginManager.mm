//
//  ConsoliAdUnityPluginManager.m
//  ConsoliAds
//
//  Created by FazalElahi on 06/02/2017.
//  Copyright © 2017 FazalElahi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ConsoliAdUnityPluginManager.h"
#import "ConsoliAdUnityPlugin.h"
#import "UnityAppController.h"

void UnitySendMessage(const char *className, const char *methodName, const char *param);

@implementation ConsoliAdUnityPluginManager

+ (void)initWithKey:(NSString*)appKey andDeviceID:(NSString*)deviceID andGameObject:(NSString*)gameObjectName isIdentifierForVendor:(int)identifierForVendor userConsent:(BOOL)consent{
    [[ConsoliAdUnityPlugin sharedPlugIn] initWithKey:appKey andDeviceID:deviceID andGameObject:gameObjectName isIdentifierForVendor:identifierForVendor userConsent:consent];
}

+ (BOOL)showInterstitial:(int)scene {
    UnityAppController* unityAppController = GetAppController();
    return [[ConsoliAdUnityPlugin sharedPlugIn] showInterstitial:scene withRootViewController:unityAppController.rootViewController];
}

+ (BOOL)isInterstitialLoaded:(int)scene {
    return [[ConsoliAdUnityPlugin sharedPlugIn] isInterstitialLoaded:scene];
}

+ (void)loadInterstitialForScene:(int)scene {
    [[ConsoliAdUnityPlugin sharedPlugIn] loadInterstitialForScene:scene];
}

+ (void)sendStatsOnPauseWithDeviceID:(NSString*)deviceID {
    [[ConsoliAdUnityPlugin sharedPlugIn] processStatsOnPauseWithDeviceID:deviceID];
}

+ (bool)isRewardedVideoAvailableForScene:(int) scene {
    return [[ConsoliAdUnityPlugin sharedPlugIn] isRewardedVideoAvailable:scene];
}

+ (void)requestRewardedVideoForScene:(int)scene {
    [[ConsoliAdUnityPlugin sharedPlugIn] requestRewardedVideoAdForScene:scene];
}

+ (void)dumpSDKData {
    [[ConsoliAdUnityPlugin sharedPlugIn] dumpAllDataFromDownloadManager];
}

+ (bool)showRewardedVideoForScene:(int) scene {
    UnityAppController* unityAppController = GetAppController();
    return [[ConsoliAdUnityPlugin sharedPlugIn] showRewardedVideoAdForScene:scene withRootViewController:unityAppController.rootViewController];
}

+ (void)sendMessageToUnity:(NSString*)gameObjectName method:(NSString*)methodName location:(NSString*)location {
    UnitySendMessage([gameObjectName UTF8String], [methodName UTF8String], [location UTF8String]);
}

extern "C" {
    
    void _initAppWithKey(char *appKey,char *deviceID,char* gameObjectName, int identifierForVendor, bool consent)
    {
        [ConsoliAdUnityPluginManager initWithKey:[NSString stringWithUTF8String:appKey] andDeviceID:[NSString stringWithUTF8String:deviceID] andGameObject:[NSString stringWithUTF8String:gameObjectName] isIdentifierForVendor:identifierForVendor userConsent:consent];
    }
    
    bool _showInterstitial(int scene)
    {
        return [ConsoliAdUnityPluginManager showInterstitial:scene];
    }
    
    bool _isInterstitialLoaded(int scene)
    {
        return [ConsoliAdUnityPluginManager isInterstitialLoaded:scene];
    }
    
    void _loadInterstitialForScene(int scene)
    {
        [ConsoliAdUnityPluginManager loadInterstitialForScene:scene];
    }
    
    void _sendStatsOnPauseWithDeviceID(char *deviceID)
    {
        return [ConsoliAdUnityPluginManager sendStatsOnPauseWithDeviceID:[NSString stringWithUTF8String:deviceID]];
    }
    
    bool _isRewardedVideoAvailable(int scene)
    {
        return [ConsoliAdUnityPluginManager isRewardedVideoAvailableForScene:scene];
    }
    
    void _requestRewardedVideo(int scene)
    {
        [ConsoliAdUnityPluginManager requestRewardedVideoForScene:scene];
    }
    
    bool _showRewardedVideo(int scene)
    {
        return [ConsoliAdUnityPluginManager showRewardedVideoForScene:scene];
    }
    
    void _dumpSDKData()
    {
        return [ConsoliAdUnityPluginManager dumpSDKData];
    }
}

@end
