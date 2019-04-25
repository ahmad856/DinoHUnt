//
//  AdvertisingIDGenerator.h
//  ConsoliAd
//
//  Created by FazalElahi on 24/11/2017.
//  Copyright © 2017 FazalElahi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "AdvertisingIDGeneraterDelegate.h"

@interface AdvertisingIDGenerator : NSObject

@property (nonatomic, weak)id<AdvertisingIDGeneraterDelegate> _delegate;

+(AdvertisingIDGenerator*)sharedInstance;

- (void)generateAdvertisingId:(id<AdvertisingIDGeneraterDelegate>)del;

@end
