module ConvertedFiles.Docs.Wikispace.ModernObjects2026Md

let file = """# Modern Objects

A survey of technologies, gadgets, and DIY projects available in 2026 that represent significant advances in personal manufacturing, energy independence, water security, and portable power. This page documents commercially available products and proven DIY approaches for off-grid and self-sufficient living.

---

## Overview

???+ note "What this page covers"
    A survey of technologies available in 2026: 18650 battery ecosystem and DIY powerwalls, atmospheric water generation, portable solar, DC-AC power systems, spot welders, and novel gadgets. This page documents commercially available products and proven DIY approaches. For networking and infrastructure, see [Datacenters and Network Infrastructure](datacenters.md) and [Hetzner Sovereign](hetzner-sovereign.md).

---

## Energy: 18650 Battery Ecosystem

The 18650 cylindrical lithium-ion cell (18mm diameter, 65.0mm length) has become the standard building block for DIY energy storage. Originally popularized by laptop battery packs and Tesla's early vehicles, these cells are now salvaged from disposable electronic devices and repurposed into high-capacity power systems.

```mermaid
flowchart LR
    S["Disposable Vapes<br/>Laptop Packs<br/>Power Tool Packs"] --> T["Cell Testing<br/>Voltage / IR / Capacity"]
    T -->|"Good cells"| A["18650 Holders<br/>No-weld assembly"]
    T -->|"Bad cells"| D["E-waste<br/>Recycling"]
    A --> B["BMS<br/>Balancing + Protection"]
    B --> C["Inverter<br/>DC to AC"]
    C --> E["Home Power<br/>5-50 kWh"]
    
    style S fill:#5a3a2d,color:#fff
    style E fill:#4a7c59,color:#fff
    style D fill:#8B0000,color:#fff

### 18650 Specifications

| Parameter | Value | Notes |
|-----------|-------|-------|
| Nominal voltage | 3.7V (3.6-4.2V range) | Li-ion chemistry |
| Typical capacity | 2,000-3,500 mAh | Varies by manufacturer |
| Energy density | 250-265 Wh/kg | Higher than lead-acid, lower than LiFePO4 |
| Cycle life | 300-500 cycles | At 100% depth of discharge |
| Discharge rate | 5-30A continuous | Varies by cell model |
| Operating temperature | -20°C to 60°C | Performance degrades at extremes |

### Disposable Vape Salvage

Single-use disposable electronic cigarettes contain one to three 18650 or 21700 cells that are typically discarded after the nicotine reservoir is depleted. These cells often retain 80-95% of their original capacity.

| Source | Typical Cell | Capacity Retention |
|--------|-------------|--------------------|
| Elf Bar BC5000 | 650mAh internal (lipo) | Variable |
| Geek Bar | 500mAh internal | Variable |
| Hyde IQ | 8mL devices | 21700 format |
| Custom mods | 18650/21700 replaceable | Highest retention |

!!! warning "Safety Considerations"
    Salvaged lithium-ion cells carry fire and explosion risk. All cells must be tested for voltage, internal resistance, and capacity before integration into packs. Cells below 2.5V, with damaged wraps, or showing physical deformation must be discarded through proper e-waste channels.

### No-Weld Battery Assembly

Modern battery holders enable pack construction without spot welding:

| Product | Configuration | Output | Price Range |
|---------|--------------|--------|-------------|
| 18650 4S spring holder | 4 cells in series | 14.8V (16.8V max) | $8-15 |
| 18650 3S2P carrier | 6 cells (3S, 2P) | 11.1V, doubled capacity | $12-20 |
| 18650 wall-mount kit | 16-64 cells | Configurable | $30-80 |
| Vruzend V2 kit | Snap-together busbars | Custom configurations | $25-50 |
| Batrium BMS holder | Integrated BMS | 12V/24V/48V | $40-100 |

### DIY Powerwall

A residential-scale energy storage system built from salvaged 18650 cells:

| Component | Specification | Purpose |
|-----------|--------------|---------|
| Cell bank | 1,000-7,000 cells | Energy storage (5-50 kWh) |
| BMS | 100A-400A rated | Cell balancing, overcharge protection |
| Inverter | 3kW-10kW pure sine | DC battery to AC household |
| Enclosure | Fire-rated steel | Thermal containment |
| Monitoring | WiFi-enabled BMS | Remote cell monitoring |

Expected cost: $1,500-5,000 for 10-30 kWh system vs. $10,000-30,000 for commercial equivalents.

---

## Water: Atmospheric Water Generation

Atmospheric water generators (AWGs) extract potable water from ambient air humidity through condensation or desiccant absorption.

### Dehumidifier-to-Water Systems

Converting commercial dehumidifiers into drinking water sources:

| Dehumidifier | Daily Output | Power Draw | Conversion Kit |
|-------------|-------------|------------|----------------|
| hOmeLabs 4,500 sq ft | 50 pints/day | 745W | Carbon filter + UV |
| Frigidaire FFAD5033W1 | 50 pints/day | 650W | 5-stage filtration |
| Waykar 130 Pints | 130 pints/day | 1,200W | RO + UV + mineral |
| Colzer 140 Pints Commercial | 140 pints/day | 1,400W | Full purification |

### Conversion Components

| Stage | Component | Purpose |
|-------|-----------|---------|
| 1 | Sediment filter | Remove dust, particles |
| 2 | Activated carbon | Remove VOCs, odors |
| 3 | Reverse osmosis | Remove dissolved solids, heavy metals |
| 4 | UV sterilization | Kill bacteria and viruses |
| 5 | Mineral cartridge | Add beneficial minerals (optional) |

### Commercial AWG Units

| Product | Output | Energy/Volume | Price | Notes |
|---------|--------|--------------|-------|-------|
| Watergen GENNY | 30L/day | 0.3 kWh/L | $1,500 | Home/office unit |
| Source Hydropanel | 3-5L/day | Solar powered | $2,000 | Off-grid, solar only |
| Zero Mass Water (SOURCE) | 4-10L/day | Solar thermal | $2,500 | Requires sunlight |
| Atlantis H2O | 100L/day | 0.25 kWh/L | $8,000 | Commercial scale |

### Water from Air Efficiency

| Relative Humidity | Water Available (per m3 air) | Dehumidifier Efficiency |
|-------------------|------------------------------|------------------------|
| 30% | 8g | Low |
| 50% | 22g | Moderate |
| 70% | 38g | Good |
| 90% | 58g | Excellent |

---

## Portable Power: DC-to-AC Inverters

### Portable Power Stations

| Product | Capacity | AC Output | DC Output | Solar Input | Price |
|---------|----------|-----------|-----------|-------------|-------|
| Jackery Explorer 1000 | 1,002Wh | 1,000W (2,000W peak) | 12V/10A | 200W max | $999 |
| EcoFlow DELTA 2 | 1,024Wh | 1,800W (2,700W peak) | 12.6V/10A | 500W max | $999 |
| Bluetti AC200MAX | 2,048Wh | 2,200W (4,800W peak) | 12V/30A | 900W max | $1,899 |
| Goal Zero Yeti 3000X | 3,032Wh | 2,000W (3,500W peak) | 12V/30A | 600W max | $3,499 |
| Anker SOLIX F2000 | 2,048Wh | 2,400W (3,600W peak) | 12V/10A | 1,000W max | $1,999 |

### DIY Portable Power

| Component | Specification | Cost |
|-----------|--------------|------|
| LiFePO4 battery | 100Ah, 12.8V (1,280Wh) | $300-500 |
| Pure sine inverter | 2,000W continuous | $150-300 |
| MPPT charge controller | 30A, 12V/24V | $80-150 |
| Battery management system | 4S, 100A | $50-100 |
| Enclosure | IP67 case | $50-100 |
| Total | 1,280Wh system | $630-1,150 |

---

## Solar Technology

### Portable Solar Panels

| Product | Wattage | Folded Size | Weight | Efficiency | Price |
|---------|---------|-------------|--------|------------|-------|
| Jackery SolarSaga 100 | 100W | 24 x 21 x 1.8 in | 10.33 lbs | 23% | $299 |
| EcoFlow 400W Rigid | 400W | 67.8 x 44.6 x 1.4 in | 48.1 lbs | 22.4% | $599 |
| Bluetti PV200 | 200W | 23.2 x 89.2 in (unfolded) | 16.1 lbs | 23.4% | $449 |
| Goal Zero Nomad 200 | 200W | 11.5 x 32 x 1 in (folded) | 22 lbs | 22% | $499 |
| Anker 531 Solar Panel | 200W | 22.8 x 85.8 in (unfolded) | 11 lbs | 23% | $449 |

### Solar Charging Times

| Power Station | 100W Panel | 200W Panel | 400W Panel |
|---------------|-----------|-----------|-----------|
| 1,000Wh | 10-12 hrs | 5-6 hrs | 2.5-3 hrs |
| 2,000Wh | 20-24 hrs | 10-12 hrs | 5-6 hrs |
| 3,000Wh | 30-36 hrs | 15-18 hrs | 7.5-9 hrs |

---

## Tools and Fabrication

### Spot Welders for Battery Assembly

| Product | Type | Pulse Energy | Price | Notes |
|---------|------|-------------|-------|-------|
| kWeld | DIY kit | 0-500J | $200 | Arduino-controlled, community-driven |
| Malectrics | Mini spot welder | 5-150J | $80 | 12V car battery powered |
| Keenport 737G | Desktop | 0.1-0.3mm nickel | $120 | MOSFET switching |
| Sunkko 709A | Professional | 0.1-0.3mm nickel | $300 | Foot pedal, dual pulse |
| Bossweld SWS-25 | Industrial | 25kVA | $2,500 | Professional grade |

### Nickel Strip Specifications

| Strip Size | Max Current | Application |
|-----------|-------------|-------------|
| 0.1mm x 8mm | 5A | Small packs, low current |
| 0.15mm x 8mm | 10A | Standard packs |
| 0.2mm x 10mm | 15A | High current packs |
| 0.3mm x 10mm | 25A | Power tool packs |

---

## Gadgets and Novelties

### Portable Appliances

| Product | Function | Power | Price | Notes |
|---------|----------|-------|-------|-------|
| EcoFlow Wave 2 | Portable AC/Heater | 600W cooling | $1,299 | 5,100 BTU, 8hr runtime |
| Jackery Explorer Mini Fridge | Refrigeration | 45W | $349 | 23L, -20°C to 10°C |
| Goksenin Mini Washing Machine | Laundry | 150W | $89 | 5L, UV sterilization |
| Venta LW25 Airwasher | Humidifier + purifier | 7W | $299 | No filters needed |
| Dreo ChefMaker | Combi fryer | 1,600W | $299 | Convection + steam |

### Diagnostic Tools

| Product | Function | Price | Resolution |
|---------|----------|-------|------------|
| ANNLOV 7" LCD Digital Microscope | Inspection camera | $45 | 1200x, 1080P screen |
| FLIR ONE Edge Pro | Thermal camera | $399 | 160 x 120, -20°C to 400°C |
| KAIWEETS HT206D | Clamp multimeter | $45 | AC/DC, True RMS, NCV |
| Uni-T UT210E | Mini clamp meter | $35 | AC/DC, capacitance |
| TOPDON ArtiDiag500 | OBD2 scanner | $129 | All-system diagnostic |

### Computing

| Product | Function | Price | Notes |
|---------|----------|-------|-------|
| Raspberry Pi 5 | Single-board computer | $60 | 2.4GHz quad-core, 8GB RAM |
| Orange Pi 5 Plus | SBC alternative | $80 | 8-core RK3588, 32GB RAM support |
| Framework Laptop 16 | Modular laptop | $1,399 | Swappable GPU, input modules |
| Steam Deck OLED | Handheld PC | $549 | 7.4" OLED, 512GB-1TB |
| Beelink SER7 | Mini PC | $550 | AMD Ryzen 7 7840HS, 32GB RAM |

---

## Related Deep Hole

- [DIY Perks YouTube](https://www.youtube.com/@DIYPerks) — DIY electronics and build projects
- [Jehu Garcia YouTube](https://www.youtube.com/@jehugarcia) — 18650 battery projects and powerwall builds
| [GreatScott! YouTube](https://www.youtube.com/@greatscottlab) — Electronics tutorials and reviews
| [18650 Battery Database](https://lygte-info.dk/) — Comprehensive battery test data
| [Second Life Storage Forum](https://secondlifestorage.com/) — DIY battery community
| [r/DIY](https://www.reddit.com/r/DIY/) — General DIY community
| [r/18650masterrace](https://www.reddit.com/r/18650masterrace/) — 18650 battery community
| [Watergen Technology](https://www.watergen.com/) — Commercial AWG manufacturer
| [Source Hydropanels](https://www.source.co/) — Solar-powered water generation
"""

let render() = file
