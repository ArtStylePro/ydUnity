specialState = true;




function InitBackLayer(filepath)
	
	backLayer = cocos2d.CCLayer:node();
	local mainScene = GameScene:getMainScene();
	mainScene:addChild(backLayer,0,1);
	
	sprite1_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_1.png");
	sprite1_1:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite1_1);
	sprite1_1:setPosition(cocos2d.CCPoint(0,495+25));
	sprite1_1:setIsVisible(false);
	
	sprite1_2_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_2.png");
	sprite1_2_1:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite1_2_1);
	sprite1_2_1:setIsVisible(false);
	
	sprite1_2_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_2.png");
	sprite1_2_2:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite1_2_2);
	sprite1_2_2:setIsVisible(false);
			
	
	sprite2_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_1.png");
	sprite2_1:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite2_1);
	sprite2_1:setPosition(cocos2d.CCPoint(0,480));
	sprite2_1:setIsVisible(false);
	
	sprite2_2_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	backLayer:addChild(sprite2_2_1);
	sprite2_2_1:setScale(0.4);
	sprite2_2_1:setPosition(cocos2d.CCPoint(80,420));
	sprite2_2_1:setIsVisible(false);

	sprite2_2_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	backLayer:addChild(sprite2_2_2);
	sprite2_2_2:setScale(0.7);
	sprite2_2_2:setPosition(cocos2d.CCPoint(80,420));
	sprite2_2_2:setIsVisible(false);
	
	sprite2_2_3 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	backLayer:addChild(sprite2_2_3);
	sprite2_2_3:setScale(0.6);
	sprite2_2_3:setPosition(cocos2d.CCPoint(280,330));
	sprite2_2_3:setIsVisible(false);
	
	sprite2_2_4 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	backLayer:addChild(sprite2_2_4);
	sprite2_2_4:setScale(1.0);
	sprite2_2_4:setPosition(cocos2d.CCPoint(280,330));
	sprite2_2_4:setIsVisible(false);
	
				
	sprite2_3 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_3.png");
	sprite2_3:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite2_3);
	sprite2_3:setIsVisible(false);	
	
	sprite2_4_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_4.png");
	sprite2_4_1:setPosition(cocos2d.CCPoint(190,340));
	backLayer:addChild(sprite2_4_1);
	sprite2_4_1:setIsVisible(false);
	
	sprite2_4_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_4.png");
	sprite2_4_2:setPosition(cocos2d.CCPoint(190,340));
	backLayer:addChild(sprite2_4_2);
	sprite2_4_2:setIsVisible(false);


    collectgarbage("setpause",100);
    collectgarbage("setstepmul",5000);
	texture = cocos2d.CCTextureCache:sharedTextureCache():addImage(filepath .. "/2_3.png");
	
	sprite2_2_1_01 = cocos2d.CCSprite:spriteWithTexture(texture,cocos2d.CCRectMake(0,0,texture:getContentSize().width,texture:getContentSize().height/2));
	sprite2_2_1_01:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_2_1_01);
	sprite2_2_1_01:setIsVisible(false);

	sprite2_2_2_02 = cocos2d.CCSprite:spriteWithTexture(texture,cocos2d.CCRectMake(0,texture:getContentSize().height/2,texture:getContentSize().width,texture:getContentSize().height/2));
	sprite2_2_2_02:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_2_2_02);
	sprite2_2_2_02:setIsVisible(false);	


	cocos2d.CCScheduler:sharedScheduler():scheduleScriptFunc("move_tick", 0.01, false);
		
	PlayBg1();
end



function PlayBg1()
	sprite2_2_1:stopAllActions();
	sprite2_2_2:stopAllActions();	
	sprite2_2_3:stopAllActions();	
	sprite2_2_4:stopAllActions();
	sprite2_3:stopAllActions();
	sprite2_4_1:stopAllActions();
	sprite2_4_2:stopAllActions();
			
	sprite2_1:setIsVisible(false);	
	sprite2_2_1:setIsVisible(false);
	sprite2_2_2:setIsVisible(false);
	sprite2_2_3:setIsVisible(false);
	sprite2_2_4:setIsVisible(false);
	sprite2_3:setIsVisible(false);
	sprite2_4_1:setIsVisible(false);
	sprite2_4_2:setIsVisible(false);
		
	
	sprite1_1:setIsVisible(true);
	sprite1_2_1:setPosition(cocos2d.CCPoint(0,480+140-100));
	sprite1_2_1:setIsVisible(true);	
	sprite1_2_2:setPosition(cocos2d.CCPoint(-153,440));	
	sprite1_2_2:setIsVisible(true);	
	
	
	sprite1_2_1:setOpacity(0);
	sprite1_2_1:setOpacity(0);	
	action121();
	action122();

	sprite2_2_1_01:setIsVisible(true);
 	sprite2_2_2_02:setIsVisible(true);
    specialState = true;
end



function action121()
	local action1 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.5),cocos2d.CCMoveTo:actionWithDuration(0.5,cocos2d.CCPoint(10,460-30)));
	local action = cocos2d.CCSequence:actionOneTwo(action1,cocos2d.CCDelayTime:actionWithDuration(3));
	local action2 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeOut:actionWithDuration(0.2),cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(0,480+140-30)));
	action = cocos2d.CCSequence:actionOneTwo(action,action2);
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(2));
	sprite1_2_1:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end

function action122()
	local action1 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.5),cocos2d.CCMoveTo:actionWithDuration(0.5,cocos2d.CCPoint(10,460-30)));
	local action = cocos2d.CCSequence:actionOneTwo(action1,cocos2d.CCDelayTime:actionWithDuration(3));
	local action2 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeOut:actionWithDuration(0.2),cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(-153,440)));
	action = cocos2d.CCSequence:actionOneTwo(action,action2);
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(2));	
	sprite1_2_2:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end


function PlayBg2()
	sprite1_1:setIsVisible(false);
	sprite1_2_1:stopAllActions();
	sprite1_2_2:stopAllActions();		
	sprite1_2_1:setIsVisible(false);	
	sprite1_2_2:setIsVisible(false);
	
	
	sprite2_3:setPosition(cocos2d.CCPoint(320,350));
	sprite2_1:setIsVisible(true);	
	sprite2_2_1:setIsVisible(true);
	sprite2_2_2:setIsVisible(true);
	sprite2_2_3:setIsVisible(true);
	sprite2_2_4:setIsVisible(true);
	sprite2_3:setIsVisible(true);
	sprite2_4_1:setIsVisible(true);
	sprite2_4_2:setIsVisible(true);	
	
	sprite2_2_1:runAction(cocos2d.CCRepeatForever:actionWithAction(cocos2d.CCRotateBy:actionWithDuration(3,-360)));
	sprite2_2_2:runAction(cocos2d.CCRepeatForever:actionWithAction(cocos2d.CCRotateBy:actionWithDuration(3,360)));

	sprite2_2_3:runAction(cocos2d.CCRepeatForever:actionWithAction(cocos2d.CCRotateBy:actionWithDuration(3,-360)));
	sprite2_2_4:runAction(cocos2d.CCRepeatForever:actionWithAction(cocos2d.CCRotateBy:actionWithDuration(3,360)));

	
	action241();
	action242();

	sprite2_2_1_01:setPosition(cocos2d.CCPoint(0,260+texture:getContentSize().height/2));	
	sprite2_2_1_01:setIsVisible(true);
	sprite2_2_2_02:setPosition(cocos2d.CCPoint(0,260));	
 	sprite2_2_2_02:setIsVisible(true);
    sprite2_2_1_01:setIsVisible(false);
    sprite2_2_2_02:setIsVisible(false);

end	


function action23()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCDelayTime:actionWithDuration(1), cocos2d.CCPlace:actionWithPosition(cocos2d.CCPoint(320,350)));
	action = cocos2d.CCSequence:actionOneTwo(action, cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(-430,350)));
	sprite2_3:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
	
	
end



function action241()
	
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCDelayTime:actionWithDuration(1),cocos2d.CCScaleTo:actionWithDuration(1,1.1));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCScaleTo:actionWithDuration(1,1));
	sprite2_4_1:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
	
end


function action242()
	
	
	local action1 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeOut:actionWithDuration(1),cocos2d.CCScaleTo:actionWithDuration(1,1.1));
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCDelayTime:actionWithDuration(0.5),action1);
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(0.5));
	local action2 = cocos2d.CCSpawn:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(1),cocos2d.CCScaleTo:actionWithDuration(1,1));
	action = cocos2d.CCSequence:actionOneTwo(action,action2);
	sprite2_4_2:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end

function backLayerCommonState()
	specialState = ture;
	PlayBg1();
end

function backlayerSpecialState()
	specialState = false;
	PlayBg2();
end

function move_tick(dt)

    if specialState then
        local scroll_y = 100.0 * dt;
        sprite2_2_1_01:setPosition(cocos2d.CCPoint(0,sprite2_2_1_01:getPosition().y+scroll_y));
        sprite2_2_2_02:setPosition(cocos2d.CCPoint(0,sprite2_2_2_02:getPosition().y+scroll_y));

        if sprite2_2_1_01:getPosition().y >= 480 then
            sprite2_2_1_01:setPosition(cocos2d.CCPoint(0,sprite2_2_2_02:getPosition().y-texture:getContentSize().height/2));
        end	

        if sprite2_2_2_02:getPosition().y >= 480 then
            sprite2_2_2_02:setPosition(cocos2d.CCPoint(0,sprite2_2_1_01:getPosition().y-texture:getContentSize().height/2));
        end
    end
end

function releaseBackLayer()
	
	specialState = false;	
	cocos2d.CCTextureCache:sharedTextureCache():removeTexture(texture);


	backLayer:removeAllChildrenWithCleanup(true);
	backLayer:removeFromParentAndCleanup(true);
	
	backLayer = nil;
	collectgarbage(); 
	
	
end



