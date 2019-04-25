//
//  ConsoliAdUnityPlugin.h
//  ConsoliAds
//
//  Created by FazalElahi on 06/02/2017.
//  Copyright © 2017 FazalElahi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface ConsoliAdUnityPlugin : NSObject

+ (ConsoliAdUnityPlugin*)sharedPlugIn;

- (void)initWithKey:(NSString*)appKey andDeviceID:(NSString*)deviceID andGameObject:(NSString*)gameObjectName_ isIdentifierForVendor:(int)identifierForVendor userConsent:(BOOL)consent;

- (BOOL)showInterstitial:(int)scene withRootViewController:(UIViewController *)viewController;

- (void)loadInterstitialForScene:(int)scene;

- (BOOL)isInterstitialLoaded:(int)scene ;

- (void)processStatsOnPauseWithDeviceID:(NSString*)deviceID;

- (void)requestRewardedVideoAdForScene:(int)sceneID ;

- (BOOL)showRewardedVideoAdForScene:(int)sceneID withRootViewController:(UIViewController*)viewController ;

- (BOOL)isRewardedVideoAvailable:(int)sceneID ;

- (void)dumpAllDataFromDownloadManager;

@end
