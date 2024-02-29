(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [
		{name:"laba4HTML5 Canvas_atlas_1", frames: [[412,350,160,120],[1930,436,71,212],[1577,0,358,188],[1577,190,358,188],[1106,277,410,136],[746,277,358,188],[746,0,275,275],[1023,0,275,275],[0,350,410,136],[1300,0,275,275],[1518,380,410,136],[729,467,71,212],[802,467,71,212],[875,467,71,212],[1937,218,83,216],[1937,0,92,216],[652,350,75,215],[1328,415,71,213],[0,0,744,348],[948,467,71,212],[1182,415,71,214],[574,350,76,215],[1255,415,71,214],[1106,415,74,212],[1401,415,71,213]]}
];


(lib.AnMovieClip = function(){
	this.currentSoundStreamInMovieclip;
	this.actionFrames = [];
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(positionOrLabel);
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		var keys = this.soundStreamDuration.keys();
		for(var i = 0;i<this.soundStreamDuration.size; i++){
			var key = keys.next().value;
			key.instance.stop();
		}
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var keys = this.soundStreamDuration.keys();
			for(var i = 0; i< this.soundStreamDuration.size ; i++){
				var key = keys.next().value; 
				var value = this.soundStreamDuration.get(key);
				if((value.end) == currentFrame){
					key.instance.stop();
					if(this.currentSoundStreamInMovieclip == key) { this.currentSoundStreamInMovieclip = undefined; }
					this.soundStreamDuration.delete(key);
				}
			}
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			if(this.soundStreamDuration.size > 0){
				var keys = this.soundStreamDuration.keys();
				var maxDuration = 0;
				for(var i=0;i<this.soundStreamDuration.size;i++){
					var key = keys.next().value;
					var value = this.soundStreamDuration.get(key);
					if(value.end > maxDuration){
						maxDuration = value.end;
						this.currentSoundStreamInMovieclip = key;
					}
				}
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:



(lib.CachedBmp_68 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(0);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_54 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(1);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_67 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(2);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_65 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(3);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_58 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(4);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_66 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(5);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_64 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(6);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_62 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(7);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_59 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(8);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_63 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(9);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_60 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(10);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_52 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(11);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_50 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(12);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_53 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(13);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_46 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(14);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_45 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(15);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_47 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(16);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_49 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(17);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_57 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(18);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_51 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(19);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_48 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(20);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_44 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(21);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_43 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(22);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_55 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(23);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_42 = function() {
	this.initialize(ss["laba4HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(24);
}).prototype = p = new cjs.Sprite();



(lib.ButtonStop = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_1 = function() {
		playSound("SpeechOffwav");
	}
	this.frame_2 = function() {
		playSound("SpeechOnwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(1).call(this.frame_1).wait(1).call(this.frame_2).wait(2));

	// Слой_1
	this.instance = new lib.CachedBmp_65();
	this.instance.setTransform(-112.5,-51.45,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_66();
	this.instance_1.setTransform(-112.5,-51.45,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_67();
	this.instance_2.setTransform(-112.5,-51.45,0.5,0.5);

	this.instance_3 = new lib.CachedBmp_68();
	this.instance_3.setTransform(-62.95,-34.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance_3}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-112.5,-51.4,179,94);


(lib.ButtonRun = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_64();
	this.instance.setTransform(-46.5,-50.45,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_62();
	this.instance_1.setTransform(-46.5,-50.45,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_63();
	this.instance_2.setTransform(-46.5,-50.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-46.5,-50.4,137.5,137.5);


(lib.ButtonReturn = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_58();
	this.instance.setTransform(-100.5,-24.45,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_59();
	this.instance_1.setTransform(-100.5,-24.45,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_60();
	this.instance_2.setTransform(-100.5,-24.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-100.5,-24.4,205,68);


(lib.ЛапаЖука = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_55();
	this.instance.setTransform(-23.55,-36.3,0.3754,0.3754);

	this.instance_1 = new lib.CachedBmp_42();
	this.instance_1.setTransform(-22.5,-36.75,0.3754,0.3754);

	this.instance_2 = new lib.CachedBmp_43();
	this.instance_2.setTransform(-22.5,-37.2,0.3754,0.3754);

	this.instance_3 = new lib.CachedBmp_44();
	this.instance_3.setTransform(-22.5,-37.65,0.3754,0.3754);

	this.instance_4 = new lib.CachedBmp_45();
	this.instance_4.setTransform(-22.5,-38.1,0.3754,0.3754);

	this.instance_5 = new lib.CachedBmp_46();
	this.instance_5.setTransform(-22.5,-37.8,0.3754,0.3754);

	this.instance_6 = new lib.CachedBmp_47();
	this.instance_6.setTransform(-22.5,-37.5,0.3754,0.3754);

	this.instance_7 = new lib.CachedBmp_48();
	this.instance_7.setTransform(-22.5,-37.2,0.3754,0.3754);

	this.instance_8 = new lib.CachedBmp_49();
	this.instance_8.setTransform(-22.5,-36.9,0.3754,0.3754);

	this.instance_9 = new lib.CachedBmp_50();
	this.instance_9.setTransform(-22.5,-36.6,0.3754,0.3754);

	this.instance_10 = new lib.CachedBmp_51();
	this.instance_10.setTransform(-22.5,-36.55,0.3754,0.3754);

	this.instance_11 = new lib.CachedBmp_52();
	this.instance_11.setTransform(-22.5,-36.5,0.3754,0.3754);

	this.instance_12 = new lib.CachedBmp_53();
	this.instance_12.setTransform(-22.5,-36.4,0.3754,0.3754);

	this.instance_13 = new lib.CachedBmp_54();
	this.instance_13.setTransform(-22.5,-36.35,0.3754,0.3754);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance_3}]},1).to({state:[{t:this.instance_4}]},1).to({state:[{t:this.instance_5}]},1).to({state:[{t:this.instance_6}]},1).to({state:[{t:this.instance_7}]},1).to({state:[{t:this.instance_8}]},1).to({state:[{t:this.instance_9}]},1).to({state:[{t:this.instance_10}]},1).to({state:[{t:this.instance_11}]},1).to({state:[{t:this.instance_12}]},1).to({state:[{t:this.instance_13}]},1).to({state:[{t:this.instance}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-23.5,-38.1,35.6,81.4);


(lib.ТелоЖука = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.ЛапаЖука("synched",4);
	this.instance.setTransform(-2.9,124.05,1.3319,1.3319,0,-150.0008,29.9992,-5.9,2.5);

	this.instance_1 = new lib.ЛапаЖука("synched",0);
	this.instance_1.setTransform(-113.9,98.35,1.3319,1.3319,0,-120.0017,59.9983,-5.9,2.4);

	this.instance_2 = new lib.ЛапаЖука("synched",0);
	this.instance_2.setTransform(107.1,106.3,1.332,1.332,0,180,0,-5.9,2.4);

	this.instance_3 = new lib.ЛапаЖука("synched",4);
	this.instance_3.setTransform(-111.85,-87.65,1.3319,1.3319,-59.9983,0,0,-5.9,2.4);

	this.instance_4 = new lib.ЛапаЖука("synched",14);
	this.instance_4.setTransform(-1.7,-113.95,1.3319,1.3319,-29.9992,0,0,-5.9,2.5);

	this.instance_5 = new lib.ЛапаЖука("synched",4);
	this.instance_5.setTransform(107.1,-95.6,1.332,1.332,0,0,0,-5.9,2.4);

	this.instance_6 = new lib.CachedBmp_57();
	this.instance_6.setTransform(-125.5,-62.45,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2,p:{startPosition:0}},{t:this.instance_1,p:{startPosition:0}},{t:this.instance}]}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2,p:{startPosition:14}},{t:this.instance_1,p:{startPosition:14}},{t:this.instance}]},29).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-171.6,-172.7,418.1,355.6);


// stage content:
(lib.laba4HTML5Canvas = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	this.actionFrames = [0,19,54,59];
	this.streamSoundSymbolsList[19] = [{id:"Жукстолнулся",startFrame:19,endFrame:59,loop:1,offset:0}];
	this.streamSoundSymbolsList[54] = [{id:"Большойжук",startFrame:54,endFrame:79,loop:1,offset:0}];
	// timeline functions:
	this.frame_0 = function() {
		this.clearAllSoundStreams();
		 
		this.buttonStop.addEventListener("click", stopA.bind(this)); 
		function stopA(args)
		{
		  this.stop(); 
		} 
		
		this.buttonRun.addEventListener("click", playA.bind(this)); 
		function playA(args)
		{
		  this.play(); 
		} 
		
		this.buttonReturn.addEventListener("click", returnA.bind(this)); 
		function returnA(args) 
		{
		   this.gotoAndStop(0);
		}
		playSound("nasekomyiemassovyiivlesudalekiiwav");
	}
	this.frame_19 = function() {
		var soundInstance = playSound("Жукстолнулся",0);
		this.InsertIntoSoundStreamData(soundInstance,19,59,1);
	}
	this.frame_54 = function() {
		var soundInstance = playSound("Большойжук",0);
		this.InsertIntoSoundStreamData(soundInstance,54,79,1);
	}
	this.frame_59 = function() {
		playSound("nasekomyiemassovyiivlesudalekiiwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(19).call(this.frame_19).wait(35).call(this.frame_54).wait(5).call(this.frame_59).wait(21));

	// Слой_19
	this.buttonReturn = new lib.ButtonReturn();
	this.buttonReturn.name = "buttonReturn";
	this.buttonReturn.setTransform(777.5,362.25);
	new cjs.ButtonHelper(this.buttonReturn, 0, 1, 2);

	this.timeline.addTween(cjs.Tween.get(this.buttonReturn).wait(80));

	// Кнопка
	this.buttonRun = new lib.ButtonRun();
	this.buttonRun.name = "buttonRun";
	this.buttonRun.setTransform(1169.1,358.4);
	new cjs.ButtonHelper(this.buttonRun, 0, 1, 2, false, new lib.ButtonRun(), 3);

	this.buttonStop = new lib.ButtonStop();
	this.buttonStop.name = "buttonStop";
	this.buttonStop.setTransform(1030.6,387.25);
	new cjs.ButtonHelper(this.buttonStop, 0, 1, 2, false, new lib.ButtonStop(), 3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.buttonStop},{t:this.buttonRun}]}).wait(80));

	// Жук3
	this.instance = new lib.ТелоЖука("synched",0);
	this.instance.setTransform(-157.15,202.5,0.5326,0.5326,29.9986,0,0,37.1,5.2);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({regX:37.2,regY:5,scaleX:0.5325,scaleY:0.5325,rotation:-45.0012,guide:{path:[-157,202.4,-159.3,200.7,-161.7,198.9,-134.4,218.2,-107.2,237.5,-66,266.7,-44.5,280.2,-8.9,302.8,22.1,316,46.8,326.6,79,335.9,98.6,341.5,137.5,350.9,201.5,366.4,234.8,372,289.3,381.1,333.4,379,369.1,377.3,412.7,367.5,439.3,361.5,490.5,346.8,615.3,311,740,275.2,756.3,270.5,764.6,267.7,778.1,263.2,788.3,258.1,811.9,246.3,843.2,216.9,851.7,208.9,868.5,192.9,883.3,179.3,895.1,170.7,938.2,139.2,1000.9,127.1,1050,117.5,1117.9,119.1,1139.3,119.6,1182.2,120.9,1219.3,121.4,1246.3,117.8,1265.2,115.3,1288.2,109.7,1303.2,106.1,1329.5,98.6,1376.5,85.3,1406.2,75.7,1447.9,62.1,1481.2,47.9,1527.7,28,1571,1.5,1614.3,-25.1,1653.1,-57.5], orient:'fixed'},startPosition:19},79).wait(1));

	// Жук2
	this.instance_1 = new lib.ТелоЖука("synched",0);
	this.instance_1.setTransform(1079.5,-11.4,0.4575,0.4575,74.9996,0,0,37.1,5);

	this.timeline.addTween(cjs.Tween.get(this.instance_1).to({regX:37,regY:4.9,rotation:119.9995,guide:{path:[1079.5,-11.4,1079.6,-10.2,1079.6,-9,1080.5,3.9,1081.6,29.8,1083,52.5,1086.5,67.4,1091.1,87,1100.8,101.6,1108.6,113.2,1121.3,123.9,1131.3,132.2,1146.3,141.5,1193.5,170.5,1267.4,196,1287.7,203,1331.1,216.7,1373.1,229.9,1394.7,237.5,1430,249.8,1471,266.8,1502.1,279.6,1546,299.2,1587.8,317.8,1611.2,330.2,1646.4,348.8,1671.9,368.7,1703,393.1,1727.3,425.7,1751.2,457.8,1766.5,495.1,1781.8,532.5,1787.3,572,1793,612.2,1787.9,651.5,1784.3,679.2,1774.9,710.9,1767.8,734.8,1759.6,753.3,1716.8,849.1,1593.2,920.8,1555.2,942.9,1486.1,974.9,1407.7,1011.3,1378,1027.2,1299.4,1069.1,1230.4,1125.1,1190.9,1157.1,1167.2,1185.9,1151.7,1204.8,1141.1,1224.1], orient:'fixed'},startPosition:19},79).wait(1));

	// Жук4
	this.instance_2 = new lib.ТелоЖука("synched",0);
	this.instance_2.setTransform(1931.55,1219.35,0.7317,0.7317,-124.5616,0,0,37,5);

	this.timeline.addTween(cjs.Tween.get(this.instance_2).to({rotation:-184.5618,guide:{path:[1931.6,1219.4,1918.8,1195.4,1900.5,1170.7,1878.9,1141.7,1831.9,1091,1793.3,1049.4,1771.5,1029.7,1736.1,997.8,1702,980.6,1669.5,964.3,1628.1,955.9,1594,949.1,1550,947.1,1531.6,946.3,1471.6,945.7,1422.9,945.3,1393.3,942.6,1368.1,940.4,1336.8,935.2,1318,932.1,1280.7,924.9,1252.2,919.5,1223.8,914,1204,910.2,1193.9,907.7,1177.5,903.6,1165,898.3,1129.5,883,1098.5,846.4,1077.2,821.2,1049.9,774.3,1033.4,746,1025.8,734.5,1011.4,712.8,996.8,698.5,980.2,682.2,954.6,666.8,923.3,648,889.4,635.8,848.6,620.9,792.4,612.1,771.5,608.9,742.4,605.5,708.9,601.7,692.2,599.8,630.5,592.6,593.3,584.2,540.3,572.1,500.3,551,491.4,546.3,469.8,533.4,450.6,521.9,439.1,516.3,427.6,510.6,413,505.1,403.1,501.3,386.2,495.5,251.6,449.3,155.5,433.5,26.6,412.3,-79.1,434.7,-113.2,441.9,-118.7,442.7,-141.2,446.1,-158.2,442.8]},startPosition:19},79).wait(1));

	// Жук1
	this.instance_3 = new lib.ТелоЖука("synched",0);
	this.instance_3.setTransform(-93.95,1130.75,0.4904,0.4904,-53.7323,0,0,37.1,5);

	this.timeline.addTween(cjs.Tween.get(this.instance_3).to({regY:5.2,scaleX:0.4997,rotation:0,skewX:-59.877,skewY:120.1229,guide:{path:[-93.8,1130.7,-88.3,1126.8,-83.3,1120,-80.3,1115.8,-75.1,1106.9,-12.7,999.1,65.7,902.2,80.1,884.3,90.2,873.6,104.4,858.6,118,848.4,141.3,831.1,175.7,818.9,196.7,811.5,238.8,801.1,256.7,796.7,265.8,794.8,280.8,791.6,293,790.1,305.2,788.7,321,788.3,327.4,788.1,349,788,541.1,787.4,732.4,759.9,773.6,753.9,798.1,747.7,833.7,738.6,859.7,723.8,879.1,712.6,901.7,692.8], orient:'fixed'},startPosition:6},36).to({regY:5.4,scaleX:0.562,skewX:-60.4055,skewY:119.5928,guide:{path:[901.6,692.8,908.8,686.5,916.3,679.3,922.4,673.4,942.1,653.6,958.1,637.5,968.2,628.2,1003,596.3,1043.8,572.3], orient:'fixed'},startPosition:9},7).to({regY:5.5,scaleX:0.5259,rotation:-35.895,skewX:0,skewY:0,guide:{path:[1043.8,572.3,1018.1,587.4,994.9,605.6], orient:'fixed'},startPosition:15},7).to({regY:5.2,scaleX:0.4904,rotation:-23.733,guide:{path:[995,605.6,1036.6,573,1085.6,550.5,1150.9,520.6,1221,512.4,1245.2,509.5,1275.7,508.8,1293.9,508.3,1330.5,508.4,1390,508.7,1449.5,509,1467.3,509,1476.2,508.5,1490.9,507.6,1502.4,504.6,1510.2,502.6,1518.9,499,1525.8,496.1,1534.7,491.6,1575.9,470.9,1620.1,437.9,1653.2,413.2,1698.1,373.4,1731.6,343.8,1752,322.6,1769.3,304.5,1791.3,277.9,1803.9,262.5,1828.9,231.5,1851.1,204.3,1867.7,186.5,1889.7,163,1910.8,145.9,1935.9,125.5,1958.6,115.8,1969.3,111.2,1984.2,107,1992.9,104.6,2010.4,100.1,2048.4,89.9,2085.2,75.5], orient:'fixed'},startPosition:19},29).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(642.6,378.2,1557.6,1010);
// library properties:
lib.properties = {
	id: '97812A233A9C5B45819179557404F954',
	width: 1920,
	height: 1080,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"images/laba4HTML5 Canvas_atlas_1.png?1678531302055", id:"laba4HTML5 Canvas_atlas_1"},
		{src:"sounds/Большойжук_.mp3?1678531302099", id:"Большойжук"},
		{src:"sounds/Жукстолнулся_.mp3?1678531302099", id:"Жукстолнулся"},
		{src:"sounds/nasekomyiemassovyiivlesudalekiiwav.mp3?1678531302099", id:"nasekomyiemassovyiivlesudalekiiwav"},
		{src:"sounds/SpeechOffwav.mp3?1678531302099", id:"SpeechOffwav"},
		{src:"sounds/SpeechOnwav.mp3?1678531302099", id:"SpeechOnwav"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['97812A233A9C5B45819179557404F954'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}			
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;			
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});			
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;			
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused){
			stageChild.syncStreamSounds();
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;