local insert = table.insert
local sort = table.sort

local layer = {}
layer.__index = layer

local function sortTiles(a, b)
	if a.data.image and b.data.image then 
		return tostring(a.data.image) < tostring(b.data.image)
	else
		return tostring(a.data) < tostring(b.data)
	end
end

function layer.new(tbl, tiles)
	local self = {}
	setmetatable(self, layer)
	
	self.tiles = {}
	self.static = {}
	self.animated = {}
	
	self.max = {x=0,y=0}
	self.min = {x=0,y=0}
	
	for _, v in ipairs(tbl) do
		local tile = {x=v.x, y=v.y, data=tiles[v.tile], layer=self, tags = v}
		if tile.tile.update then
			insert(self.animated, tile)
		else
			insert(self.static, tile)
		end
		insert(self.tiles, tile)
		if #tile.data.quads ~= 0 then
			local _, _, w, h = tile.data.quads[1]:getViewport()
			if v.x + w > self.max.x then self.max.x = v.x + w end
			if v.y + h > self.max.y then self.max.y = v.y + h end	
			if v.x < self.min.x then self.min.x = v.x end
			if v.y < self.min.y then self.min.y = v.y end
		end
	end

	self.tags = {}
	for k, v in pairs(tbl) do
		if type(k) ~= "number" then
			self.tags[k] = v
		end
	end
	
	self.isAnimated = #self.animated ~= 0
	
	if #self.static > 1 then
		sort(self.static, function(a, b) )
	end
	if #self.animated > 1 then
		sort(self.animated, function(a, b) return tostring(a.data.image) < tostring(b.data.image) end)
	end
	
	return self
end

function layer:filter(key, value, func, disfunc)
	if disfunc then
		for _, tile in ipairs(self.tiles) do
			if tile.data.tags[key] == value then
				func(tile)
			else
				disfunc(tile)
			end
		end
	else
		for _, tile in ipairs(self.tiles) do
			if tile.data.tags[key] == value then
				func(tile)
			end
		end
	end
end

function layer:drawStatic()
	for _, v in ipairs(self.tiles) do
		v.data:draw(v.x, v.y)
	end
end

function layer:drawAnimated()
	for _, v in ipairs(self.animated) do
		v.data:draw(v.x, v.y)
	end
end

return layer