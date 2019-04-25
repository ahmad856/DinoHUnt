//
//  AdvertisingIDUnityWrapper.m
//  ConsoliAd
//
//  Created by FazalElahi on 24/11/2017.
//  Copyright © 2017 FazalElahi. All rights reserved.
//

#import "AdvertisingIDUnityWrapper.h"
#import "AdvertisingIDGenerator.h"

@interface AdvertisingIDUnityWrapper() <AdvertisingIDGeneraterDelegate>
{
    NSString *gameObjectName;
}
@end

#if UNITY_IOS
void UnitySendMessage(const char *className, const char *methodName, const char *param);
#endif


@implementation AdvertisingIDUnityWrapper

+(AdvertisingIDUnityWrapper*)sharedInstance {
    
    static AdvertisingIDUnityWrapper *shareInstance;
    
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        shareInstance = [[AdvertisingIDUnityWrapper alloc] init];
    });
    
    return shareInstance;
}

- (instancetype)init {
    if (self = [super init]) {
        
    }
    return self;
}

- (void)setGameObjectName:(NSString*)gameObject {
    gameObjectName = gameObject;
}

+ (void)generateAdvertisingId:(NSString*)gameObject {
    
    AdvertisingIDUnityWrapper *wrapper = [AdvertisingIDUnityWrapper sharedInstance];
    [wrapper setGameObjectName:gameObject];
    [[AdvertisingIDGenerator sharedInstance] generateAdvertisingId:wrapper];
}

#pragma mark
#pragma mark AdvertisingIDGeneraterDelegate

- (void)didFailedToGenerateAdvertisingID:(NSString *)reason {
    [self sendMessageToUnity:gameObjectName method:@"didFailedToGenerateAdvertisingID" location:reason];
}

- (void)didGeneratedAdvertisingID:(NSString*)advertisingID {
    [self sendMessageToUnity:gameObjectName method:@"didGeneratedAdvertisingID" location:advertisingID];
}

#pragma mark
#pragma mark Sending Messages To Unity

- (void)sendMessageToUnity:(NSString*)gameObject method:(NSString*)methodName location:(NSString*)location {
    NSLog(@"sendMessageToUnit: gameObjectName: %@ ,methodName : %@ location: %@",gameObject,methodName, location);
    UnitySendMessage([gameObject UTF8String], [methodName UTF8String], [location UTF8String]);
}


extern "C" {
    
    bool _generateAdvertisingId(char* gameObjectName)
    {
        [AdvertisingIDUnityWrapper generateAdvertisingId:[NSString stringWithUTF8String:gameObjectName]];
        return true;
    }
    
}

@end
