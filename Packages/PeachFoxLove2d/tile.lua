local lg = love.graphics

local tile = {}
tile.__index = tile

local function update(self, dt)
	self.dTime = self.dTime + dt
	while self.dTime > self.time do
		self.dTime = self.dTime - self.time
		self.index = self.index + 1
		if self.index > #self.quads then
			self.index = 1
		end
	end
end

local function draw(self)
	lg.draw(self.image, self.quads[self.index], x, y)
end

function tile.new(tbl, image)
	local self = {}
	setmetatable(self, tile)
	
	if tbl.time then --Make animated
		self.update = update
		self.time = tbl.time
		self.dTime = 0
	end
	
	if tbl.image and tbl.quad then
		self.draw = draw
		self.image = image
		
		self.quads = {}
		for i=1, #tbl.quad, 4 do
			table.insert(self.quads, lg.newQuad(tbl.quad[i], tbl.quad[i+1], tbl.quad[i+2], tbl.quad[i+3], tbl.image:getDimensions()))
		end
		assert(#self.quads ~= 0, "Tile Quads table invalid size of 0")
		self.index = 1
	end

	self.tags = tbl
	
	return self
end

return tile