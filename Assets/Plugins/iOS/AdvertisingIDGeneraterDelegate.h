//
//  AdvertisingIDGeneraterDelegate.h
//  ConsoliAd
//
//  Created by FazalElahi on 24/11/2017.
//  Copyright © 2017 FazalElahi. All rights reserved.
//

#ifndef AdvertisingIDGeneraterDelegate_h
#define AdvertisingIDGeneraterDelegate_h

#import <Foundation/Foundation.h>

@protocol AdvertisingIDGeneraterDelegate <NSObject>

- (void)didGeneratedAdvertisingID:(NSString*)advertisingID;
- (void)didFailedToGenerateAdvertisingID:(NSString*)reason;

@end

#endif /* AdvertisingIDGeneraterDelegate_h */
