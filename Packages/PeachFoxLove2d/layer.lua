local insert = table.insert

local layer = {}
layer.__index = layer

function layer.new(tbl, tiles)
	local self = {}
	setmetatable(self, layer)
	
	self.tiles = {}
	self.static = {}
	self.animated = {}
	
	self.max = {x=0,y=0}
	self.min = {x=0,y=0}
	
	for _, v in ipairs(tbl) do
		local tile = {x=v.x, y=v.y, tile=tiles[v.tile],layer=self}
		if tiles[v.tile].update then
			insert(self.animated, tile)
		else
			insert(self.static, tile)
		end
		insert(self.tiles, tile)
		local _ _, w, h = tiles[v.tile].quads[1]:getViewport()
		if v.x + w > self.max.x then self.max.x = v.x + w end
		if v.y + h > self.max.y then self.max.y = v.y + h end	
		if v.x < self.min.x then self.min.x = v.x end
		if v.y < self.min.y then self.min.y = v.y end
	end
	
	self.isAnimated = #self.animated ~= 0
	
	if #self.static > 1 then
		sort(self.static, function(a, b) 
				return a.tile.image < b.tile.image end)
	end
	if #self.animated > 1 then
		sort(self.animated, function(a, b) 
				return a.tile.image < b.tile.image end)
	end
	
	return self
end

function layer:drawStatic()
	for _, v in ipairs(self.tiles) do
		v.tile:draw(v.x, v.y)
	end
end

function layer:drawAnimated()
	for _, v in ipairs(self.animated) do
		v.tile:draw(v.x, v.y)
	end
end

return layer