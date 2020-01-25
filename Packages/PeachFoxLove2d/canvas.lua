local lg = love.graphics

local canvas = {}
canvas.__index = canvas

--[[
	Properties

	.tiles           Table of all tiles                       @ tile.lua
	.layers          Table of layers this canvas draws        @ layer.lua
	.canvas          Canvas drawn to                          @ Love2d Canvas
	.orginX, .orginY Orgin of the canvas
]]

function canvas.new(layers)
	local self = {}
	setmetatable(self, canvas)
	
	self.layers = layers
	local maxX, maxY = 0, 0
	local minX, minY = 0, 0
	
	for _, v in ipairs(layers) do
		if v.maxX > maxX then maxX = v.maxX end
		if v.maxY > maxY then maxY = v.maxY end
		if v.minX < minX then minX = v.minX end
		if v.minY < minY then minY = v.minY end
	end
	
	self.canvas = lg.newCanvas(maxX-minX, maxY-minY)
	self.orginX, self.orginY = minX, minY
	
	self:updateCanvas()
	
	return self
end

function canvas:updateCanvas()
	self.canvas:renderTo(function()
		lg.push()
		lg.translate(self.orginX, self.orginY)
		for _, v in ipairs(self.layers) do
			v:drawStatic()
		end
		lg.pop()
	end)
end

function canvas:draw()
	lg.draw(self.canvas, -self.orginX, -self.orginY)
	for _, v in ipairs(self.layers) do
		v:drawAnimated()
	end
end

return canvas