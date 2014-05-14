commonState = true;
specialState = false;
function InitBackLayer(filepath)

	backLayer = cocos2d.CCLayer:node();
	local mainScene = GameScene:getMainScene();
	mainScene:addChild(backLayer,0,1);


    collectgarbage("setpause",100);
    collectgarbage("setstepmul",5000);

	texture = cocos2d.CCTextureCache:sharedTextureCache():addImage(filepath .. "/1_1.png");

	texture2_1 = cocos2d.CCTextureCache:sharedTextureCache():addImage(filepath .. "/2_1.png");

	sprite1_1_1 = cocos2d.CCSprite:spriteWithTexture(texture,cocos2d.CCRectMake(0,0,texture:getContentSize().width,texture:getContentSize().height/2));
	sprite1_1_1:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_1_1);
	sprite1_1_1:setIsVisible(false);


	sprite1_1_2 = cocos2d.CCSprite:spriteWithTexture(texture,cocos2d.CCRectMake(0,texture:getContentSize().height/2,texture:getContentSize().width,texture:getContentSize().height/2));
	sprite1_1_2:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_1_2);
	sprite1_1_2:setIsVisible(false);
	
	sprite1_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_2.png");
	sprite1_2:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite1_2);
	sprite1_2:setPosition(cocos2d.CCPoint(50,420));	
	sprite1_2:setIsVisible(false);

	sprite1_3 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_3.png");
	sprite1_3:setAnchorPoint(cocos2d.CCPoint(0,1));
	backLayer:addChild(sprite1_3);
	sprite1_3:setPosition(cocos2d.CCPoint(-25,455));	
	sprite1_3:setIsVisible(false);	

	sprite1_4 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_4.png");
	sprite1_4:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_4);
	sprite1_4:setIsVisible(false);
	
	sprite1_5 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_5.png");
	sprite1_5:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_5);	
	sprite1_5:setIsVisible(false);	


	sprite1_6 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_6.png");
	sprite1_6:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_6);	
	sprite1_6:setIsVisible(false);
	
	sprite1_7 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_7.png");
	sprite1_7:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite1_7);	
	sprite1_7:setIsVisible(false);
	
	sprite1_8 = cocos2d.CCSprite:spriteWithFile(filepath .. "/1_8.png");
	sprite1_8:setAnchorPoint(cocos2d.CCPoint(0,1));	
	backLayer:addChild(sprite1_8);	
	sprite1_8:setIsVisible(false);		



	sprite2_1_1 = cocos2d.CCSprite:spriteWithTexture(texture2_1,cocos2d.CCRectMake(0,0,texture2_1:getContentSize().width,texture2_1:getContentSize().height/2));
	sprite2_1_1:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_1_1);
	sprite2_1_1:setIsVisible(false);

	sprite2_1_2 = cocos2d.CCSprite:spriteWithTexture(texture2_1,cocos2d.CCRectMake(0,texture2_1:getContentSize().height/2,texture2_1:getContentSize().width,texture2_1:getContentSize().height/2));
	sprite2_1_2:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_1_2);
	sprite2_1_2:setIsVisible(false);
	


	sprite2_2_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	sprite2_2_1:setAnchorPoint(cocos2d.CCPoint(0,1));	
	backLayer:addChild(sprite2_2_1);	
	sprite2_2_1:setIsVisible(false);
	
	sprite2_2_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_2.png");
	sprite2_2_2:setScale(0.8);
	sprite2_2_2:setFlipX(true);
	sprite2_2_2:setAnchorPoint(cocos2d.CCPoint(0,1));	
	backLayer:addChild(sprite2_2_2);	
	sprite2_2_2:setIsVisible(false);
	
	sprite2_3 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_3.png");
	sprite2_3:setAnchorPoint(cocos2d.CCPoint(0,1));	
	backLayer:addChild(sprite2_3);	
	sprite2_3:setPosition(cocos2d.CCPoint(10,480));	
	sprite2_3:setIsVisible(false);	
	
	sprite2_4 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_4.png");
	backLayer:addChild(sprite2_4);	
	sprite2_4:setPosition(cocos2d.CCPoint(300,460));	
	sprite2_4:setIsVisible(false);		

	sprite2_5_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_5.png");
	sprite2_5_1:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_5_1);
	sprite2_5_1:setPosition(cocos2d.CCPoint(220,420));
	sprite2_5_1:setIsVisible(false);
	
	sprite2_5_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_5.png");
	sprite2_5_2:setAnchorPoint(cocos2d.CCPoint(0,0));		
	backLayer:addChild(sprite2_5_2);	
	sprite2_5_2:setPosition(cocos2d.CCPoint(200,300));	
	sprite2_5_2:setIsVisible(false);	


	sprite2_5_3 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_5.png");
	sprite2_5_3:setAnchorPoint(cocos2d.CCPoint(0,0));		
	backLayer:addChild(sprite2_5_3);	
	sprite2_5_3:setPosition(cocos2d.CCPoint(260,310));	
	sprite2_5_3:setIsVisible(false);
	
	sprite2_6_1 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_6.png");
	sprite2_6_1:setAnchorPoint(cocos2d.CCPoint(0,0));
	backLayer:addChild(sprite2_6_1);
	sprite2_6_1:setPosition(cocos2d.CCPoint(160,410));
	sprite2_6_1:setIsVisible(false);
	
	sprite2_6_2 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_6.png");
	sprite2_6_2:setAnchorPoint(cocos2d.CCPoint(0,0));		
	backLayer:addChild(sprite2_6_2);	
	sprite2_6_2:setPosition(cocos2d.CCPoint(200,350));	
	sprite2_6_2:setIsVisible(false);	
	
	
	sprite2_7 = cocos2d.CCSprite:spriteWithFile(filepath .. "/2_7.png");
	sprite2_7:setAnchorPoint(cocos2d.CCPoint(0,1));		
	backLayer:addChild(sprite2_7);	
	sprite2_7:setPosition(cocos2d.CCPoint(-2,480));	
	sprite2_7:setIsVisible(false);
	
	cocos2d.CCScheduler:sharedScheduler():scheduleScriptFunc("move_tick", 0.01, false);
	
	
	PlayBg1();
end

function PlayBg1()

	sprite2_1_1:stopAllActions();
 	sprite2_1_2:stopAllActions();
	sprite2_2_1:stopAllActions();
	sprite2_2_2:stopAllActions();
	sprite2_3:stopAllActions();
	sprite2_4:stopAllActions();
	sprite2_5_1:stopAllActions();
	sprite2_5_2:stopAllActions();	
	sprite2_5_3:stopAllActions();		
	sprite2_6_1:stopAllActions();		
	sprite2_6_2:stopAllActions();	
	sprite2_7:stopAllActions();


	
	sprite2_1_1:setIsVisible(false);
 	sprite2_1_2:setIsVisible(false);
	sprite2_2_1:setIsVisible(false);
	sprite2_2_2:setIsVisible(false);
	sprite2_3:setIsVisible(false);
	sprite2_4:setIsVisible(false);
	sprite2_5_1:setIsVisible(false);
	sprite2_5_2:setIsVisible(false);	
	sprite2_5_3:setIsVisible(false);		
	sprite2_6_1:setIsVisible(false);		
	sprite2_6_2:setIsVisible(false);	
	sprite2_7:setIsVisible(false);
	
	
	
	sprite1_1_1:setPosition(cocos2d.CCPoint(0,0));	
	sprite1_1_1:setIsVisible(true);
	sprite1_1_2:setPosition(cocos2d.CCPoint(0,-1+texture:getContentSize().height/2));	
 	sprite1_1_2:setIsVisible(true);
 	sprite1_2:setIsVisible(true);
 	sprite1_3:setIsVisible(true);

 	sprite1_4:setPosition(cocos2d.CCPoint(320,410));	
 	sprite1_5:setPosition(cocos2d.CCPoint(320,410-40));	
 	sprite1_6:setPosition(cocos2d.CCPoint(320,410-2*40));	
 	sprite1_7:setPosition(cocos2d.CCPoint(320,410-3*37));	
 	sprite1_8:setPosition(cocos2d.CCPoint(300,510));


 	sprite1_4:setIsVisible(true);
 	sprite1_5:setIsVisible(true);
 	sprite1_6:setIsVisible(true);
 	sprite1_7:setIsVisible(true);
 	sprite1_8:setIsVisible(true);

	action141();

end

function action141()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(200,sprite1_4:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action151"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_4:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(160,sprite1_4:getPosition().y)));
	sprite1_4:runAction(action);		
end	

function action151()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(200,sprite1_5:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action161"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_5:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(160,sprite1_5:getPosition().y)));
	sprite1_5:runAction(action);	
end
function action161()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(200,sprite1_6:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action171"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_6:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(160,sprite1_6:getPosition().y)));
	sprite1_6:runAction(action);
end

function action171()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(200,sprite1_7:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action142"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_7:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(160,sprite1_7:getPosition().y)));
	sprite1_7:runAction(action);
end

function action142()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCDelayTime:actionWithDuration(2),cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_4:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCCallFunc:actionWithScriptFuncName("action152"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(320,sprite1_4:getPosition().y)));
	sprite1_4:runAction(action);		
end

function action152()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_5:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action162"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(320,sprite1_5:getPosition().y)));
	sprite1_5:runAction(action);		
end

function action162()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_6:getPosition().y)),cocos2d.CCCallFunc:actionWithScriptFuncName("action172"));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(320,sprite1_6:getPosition().y)));
	sprite1_6:runAction(action);		
end

function action172()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_7:getPosition().y)),cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(320,sprite1_7:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(0.5));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCCallFunc:actionWithScriptFuncName("action18"));	
	sprite1_7:runAction(action);		
end


function action18()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(200,sprite1_8:getPosition().y)),cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_8:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(160,sprite1_8:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(2));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.1,cocos2d.CCPoint(140,sprite1_8:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(0.2,cocos2d.CCPoint(320,sprite1_8:getPosition().y)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCCallFunc:actionWithScriptFuncName("action141"));	
	
	sprite1_8:runAction(action);		
end


function move_tick(dt)

	if commonState then
		local scroll_y = 100.0 * dt;
		sprite1_1_1:setPosition(cocos2d.CCPoint(0,sprite1_1_1:getPosition().y-scroll_y));
		sprite1_1_2:setPosition(cocos2d.CCPoint(0,sprite1_1_2:getPosition().y-scroll_y));
	
		if sprite1_1_1:getPosition().y <= 210 - texture:getContentSize().height/2 then
			sprite1_1_1:setPosition(cocos2d.CCPoint(0,-1+texture:getContentSize().height/2+sprite1_1_2:getPosition().y));
		end	
	
		if sprite1_1_2:getPosition().y <= 210 - texture:getContentSize().height/2 then
			sprite1_1_2:setPosition(cocos2d.CCPoint(0,-1+texture:getContentSize().height/2+sprite1_1_1:getPosition().y));
		end
	end
		
	if specialState then
		local scroll_y_2 = 100.0 * dt;
		sprite2_1_1:setPosition(cocos2d.CCPoint(-10,sprite2_1_1:getPosition().y+scroll_y_2));
		sprite2_1_2:setPosition(cocos2d.CCPoint(-10,sprite2_1_2:getPosition().y+scroll_y_2));
	
		if sprite2_1_1:getPosition().y >= 480 then
			sprite2_1_1:setPosition(cocos2d.CCPoint(-10,4+sprite2_1_2:getPosition().y-texture2_1:getContentSize().height/2));
		end	
	
		if sprite2_1_2:getPosition().y >= 480 then
			sprite2_1_2:setPosition(cocos2d.CCPoint(-10,4+sprite2_1_1:getPosition().y-texture2_1:getContentSize().height/2));
		end
	end
end

function PlayBg2()

	sprite1_1_1:stopAllActions();
 	sprite1_1_2:stopAllActions();
 	sprite1_2:stopAllActions();
 	sprite1_3:stopAllActions();
 	sprite1_4:stopAllActions();
 	sprite1_5:stopAllActions();
 	sprite1_6:stopAllActions();
 	sprite1_7:stopAllActions();
 	sprite1_8:stopAllActions();

	
	sprite1_1_1:setIsVisible(false);
 	sprite1_1_2:setIsVisible(false);
 	sprite1_2:setIsVisible(false);
 	sprite1_3:setIsVisible(false);
 	sprite1_4:setIsVisible(false);
 	sprite1_5:setIsVisible(false);
 	sprite1_6:setIsVisible(false);
 	sprite1_7:setIsVisible(false);
 	sprite1_8:setIsVisible(false);


	sprite2_1_1:setPosition(cocos2d.CCPoint(-10,260+texture2_1:getContentSize().height/2));
	sprite2_1_1:setIsVisible(true);
	sprite2_1_2:setPosition(cocos2d.CCPoint(-10,260));
 	sprite2_1_2:setIsVisible(true);
	sprite2_2_1:setPosition(cocos2d.CCPoint(160,330));
	sprite2_2_1:setIsVisible(true);
	sprite2_2_2:setPosition(cocos2d.CCPoint(-70,360));
	sprite2_2_2:setIsVisible(true);
	sprite2_3:setIsVisible(true);
	sprite2_4:setIsVisible(true);
	sprite2_5_1:setIsVisible(true);
	sprite2_5_2:setIsVisible(true);	
	sprite2_5_3:setIsVisible(true);		
	sprite2_6_1:setIsVisible(true);		
	sprite2_6_2:setIsVisible(true);	
	sprite2_7:setIsVisible(true);
	
	action221();	
	action222();
	
	action24();
	action251();
	action252();
	action253();

	action261();
	action262();			
end	



function action221()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(150,340)),cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(140,330)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(160,330)));
	sprite2_2_1:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end

function action222()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(-60,370)),cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(-50,360)));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCMoveTo:actionWithDuration(1,cocos2d.CCPoint(-70,360)));
	sprite2_2_2:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end

function action24()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCScaleTo:actionWithDuration(0.2,1.2),cocos2d.CCScaleTo:actionWithDuration(0.2,1));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCScaleTo:actionWithDuration(0.2,1.2));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCScaleTo:actionWithDuration(0.2,1));
	action = cocos2d.CCSequence:actionOneTwo(action,cocos2d.CCDelayTime:actionWithDuration(1));	
	sprite2_4:runAction(cocos2d.CCRepeatForever:actionWithAction(action));
end

function action251()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.3),cocos2d.CCFadeOut:actionWithDuration(0.3));
	sprite2_5_1:runAction(cocos2d.CCRepeatForever:actionWithAction(action));	
end

function action252()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.2),cocos2d.CCFadeOut:actionWithDuration(0.2));
	sprite2_5_2:runAction(cocos2d.CCRepeatForever:actionWithAction(action));	
end

function action253()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.4),cocos2d.CCFadeOut:actionWithDuration(0.4));
	sprite2_5_3:runAction(cocos2d.CCRepeatForever:actionWithAction(action));	
end

function action261()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.3),cocos2d.CCFadeOut:actionWithDuration(0.3));
	sprite2_6_1:runAction(cocos2d.CCRepeatForever:actionWithAction(action));	
end

function action262()
	local action = cocos2d.CCSequence:actionOneTwo(cocos2d.CCFadeIn:actionWithDuration(0.5),cocos2d.CCFadeOut:actionWithDuration(0.5));
	sprite2_6_2:runAction(cocos2d.CCRepeatForever:actionWithAction(action));	
end

function backLayerCommonState()
	commonState = true;
	specialState = false;
	PlayBg1();
end

function backlayerSpecialState()
	commonState = false;
	specialState = true;
	PlayBg2();
end

function releaseBackLayer()
    commonState = false;
    specialState = false;
    cocos2d.CCTextureCache:sharedTextureCache():removeTexture(texture);
    cocos2d.CCTextureCache:sharedTextureCache():removeTexture(texture2_1);
	backLayer:removeAllChildrenWithCleanup(true);
	backLayer:removeFromParentAndCleanup(true);	
	backLayer = nil;
	collectgarbage(); 
end




