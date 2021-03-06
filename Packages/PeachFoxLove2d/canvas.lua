local lg = love.graphics

local canvas = {}
canvas.__index = canvas

--[[
	Properties

	.tiles             Table of all tiles                       @ tile.lua
	.layers            Table of layers this canvas draws        @ layer.lua
	.canvas            Canvas drawn to                          @ Love2d Canvas
	.originX, .originY Origin of the canvas
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
	self.originX, self.originY = minX, minY
	
	self:updateCanvas()
	
	return self
end

function canvas:updateCanvas()
	lg.setCanvas(self.canvas)
	lg.push('all')
	lg.origin()
	lg.setColor(1,1,1,1)
	lg.translate(-self.originX, -self.originY)
	for _, layer in ipairs(self.layers) do
		layer:drawStatic()
	end
	lg.pop()
	lg.setCanvas()
end

function canvas:draw()
	lg.draw(self.canvas, self.originX, self.originY)
	for _, layer in ipairs(self.layers) do
		layer:drawAnimated()
	end
end

return canvas