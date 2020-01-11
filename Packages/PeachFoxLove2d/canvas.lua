local lg = love.graphics

local canvas = {}
canvas.__index = canvas

function canvas.new(layers)
	local self = {}
	setmetatable(self, canvas)
	
	self.layers = layers
	local max = {x=0,y=0}
	local min = {x=0,y=0}
	
	for _, v in ipairs(layers) do
		if v.max.x > max.x then max.x = v.max.x end
		if v.max.y > max.y then max.y = v.max.y end
		if v.min.x < min.x then min.x = v.min.x end
		if v.min.y < min.y then min.y = v.min.y end
	end
	
	self.canvas = lg.newCanvas(max.x-min.x, max.y-min.y)
	self.orgin = min
	
	self:updateCanvas()
	
	return self
end

function canvas:updateCanvas()
	lg.setCanvas(self.canvas)
	lg.push()
	lg.translate(self.orgin.x, self.orgin.y)
	for _, v in ipairs(self.layers) do
		v:drawStatic()
	end
	lg.pop()
	lg.setCanvas()
end

function canvas:draw()
	lg.draw(self.canvas, -self.orgin.x, -self.orgin.y)
	for _, v in ipairs(self.layers) do
		v:drawAnimated()
	end
end

return canvas