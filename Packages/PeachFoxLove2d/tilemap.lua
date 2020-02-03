local PATH = (...):match("(.-)[^%.]+$")
local TILE = require(PATH.."tile")
local LAYER = require(PATH.."layer")
local CANVAS = require(PATH.."canvas")
local MAP = require(PATH.."map")

local insert = table.insert

local tilemap = {}
tilemap.__index = tilemap

--[[
	Properties

	.tiles          Table of all tiles                       @ tile.lua
	.animatedTiles  Table of tiles with an update function   @ tile.lua
	.layers         Table of all layers                      @ layer.lua
	.canvases       Table of all canvases                    @ canvas.lua
	.map            Table of tiles indexed by position       @ map.lua
]]

function tilemap.new(tbl, tilesets)
	local self = {}
	setmetatable(self, tilemap)
	
	self:addTiles(tbl.tiles, tilesets)
	self:addLayers(tbl.layers)
	
	self:addCanvases(self.layers)
	self:generateMap()
	
	return self
end

local function makeTile(tile, images)
	return TILE.new(tile, tile.image and images[tile.image] or nil)
end

function tilemap:addTiles(tbl, tilesets)
	self.animatedTiles = self.animatedTiles or {}
	self.tiles = self.tiles or {}
	
	for _, v in ipairs(tbl) do
		local tile = makeTile(v, tilesets)
		insert(self.tiles, tile)
		if tile.update then
			insert(self.animatedTiles, tile)
		end
	end
end

local function makeLayer(tbl, tiles)
	return LAYER.new(tbl, tiles)
end

function tilemap:addLayers(tbl)
	self.layers = self.layers or {}
	for _, v in ipairs(tbl) do
		insert(self.layers, makeLayer(v, self.tiles))
	end
end

function tilemap:addCanvases(layers)
	self.canvases = self.canvases or {}
	local stack = {}
	
	for _, layer in ipairs(layers) do
		if layer.isAnimated and #stack ~= 0 then
			insert(stack, layer)
			insert(self.canvases, CANVAS.new(stack))
			stack = {}
		else
			insert(stack, layer)
		end
	end
	if #stack ~= 0 then
		insert(self.canvases, CANVAS.new(stack))
	end
end

-- Redraw static tiles
function tilemap:refreshStaticTiles()
	for _, v in ipairs(self.canvases) do
		v:updateCanvas()
	end
end

function tilemap:generateMap()
	self.map = MAP.new(self.layers)
end

function tilemap:update(dt)
	for _, v in ipairs(self.animatedTiles) do
		v:update(dt)
	end
end

function tilemap:draw()
	for _, v in ipairs(self.canvases) do
		v:draw()
	end
end

return tilemap